using MediatR;
using MedicalReports.Application.Dtos;
using MedicalReports.Application.Interfaces;
using MedicalReports.Application.Queries;
using MedicalReports.Core.Entities;
using MedicalReports.Core.Enums;
using Microsoft.EntityFrameworkCore;

namespace MedicalReports.Application.Handlers
{
    public class GetPatientHealthReportHandler : IRequestHandler<GetPatientHealthReportQuery, HealthReportDto>
    {
        private readonly IAppDbContext _dbContext;

        public GetPatientHealthReportHandler(IAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<HealthReportDto> Handle(GetPatientHealthReportQuery request, CancellationToken cancellationToken)
        {
            var patient = await _dbContext.Patients
                .Include(p => p.BloodWork)
                .Include(p => p.Questionnaires)
                .FirstOrDefaultAsync(p => p.Id == request.PatientId, cancellationToken);

            if (patient == null)
            {
                throw new InvalidOperationException($"Patient with Id: {request.PatientId} not found.");
            }

            var guidelines = await _dbContext.Guidelines
                                .Include(g => g.GuidelineItems)
                                .Where(g => g.IsActive)
                                .ToListAsync(cancellationToken);

            var bloodWorkResults = GetBloodWorkResults(patient.BloodWork, guidelines);
            var questionnaireResults = GetQuestionnaireResults(patient.Questionnaires, guidelines);

            var patientReport = new HealthReportDto
            {
                PatientId = patient.Id,
                PatientName = patient.Name,
                ReportDate = DateTime.UtcNow,
                ReportItems = bloodWorkResults.Concat(questionnaireResults).ToList(),
            };

            return patientReport;
        }

        private List<HealthReportItemDto> GetBloodWorkResults(List<PatientBloodWork> bloodWork, List<Guideline> guidelines)
        {
            var results = new List<HealthReportItemDto>();

           foreach(var item in bloodWork)
            {
                var healthReportItem = GetHealthAssessment(
                    item.Category,
                    item.SubCategory,
                    item.Value,
                    item.Value.ToString(),
                    guidelines);

                results.Add(healthReportItem);
            }
            return results;
        }

        private List<HealthReportItemDto> GetQuestionnaireResults(List<PatientQuestionnaire> questionnaires, List<Guideline> guidelines)
        {
            var results = new List<HealthReportItemDto>();

            foreach (var item in questionnaires)
            {
                var healthReportItem = GetHealthAssessment(
                    item.Category,
                    item.SubCategory,
                    item.NumericValue,
                    item.ResponseValue,
                    guidelines);

                results.Add(healthReportItem);
            }
            return results;
        }

        private GuidelineItem? FindMatchingGuidelineItem(Guideline guideline, decimal? numericValue, string? textValue)
        {
            if (guideline.MatchingType == MatchingType.Numeric && numericValue.HasValue)
            {
                return guideline.GuidelineItems.FirstOrDefault(item =>
                    IsValueInRange(numericValue.Value, item.MinValue, item.MaxValue));
            }
            else if (textValue != null)
            {
                return guideline.GuidelineItems.FirstOrDefault(item =>
                    string.Equals(item.TextualValue, textValue, StringComparison.OrdinalIgnoreCase));
            }

            return null;
        }

        private HealthReportItemDto GetHealthAssessment(string category, string? subCategory, decimal? numericValue, string textValue, List<Guideline> guidelines)
        {
            var healthReportItem = new HealthReportItemDto
            {
                Name = FormatName(category, subCategory),
                Value = textValue,
            };

            // Find matching guideline
            var guideline = FindMatchingGuideline(category, subCategory, guidelines);

            if (guideline == null)
            {
                healthReportItem.Status = HealthStatus.NeedsAttention.ToString();
                healthReportItem.Note = "Guideline not found";
            }
            else
            {
                // Compare patient value with guideline item
                var matchingItem = FindMatchingGuidelineItem(guideline, numericValue, textValue);

                if (matchingItem != null)
                {
                    healthReportItem.Status = matchingItem.Status.ToString();
                }
                else
                {
                    healthReportItem.Status = HealthStatus.NeedsAttention.ToString();
                    healthReportItem.Note = "Value does not match guideline";
                }
            }
            return healthReportItem;
        }

        private Guideline? FindMatchingGuideline(string category, string? subCategory, List<Guideline> guidelines)
        {
            return guidelines.FirstOrDefault(g =>
                    string.Equals(g.Category, category, StringComparison.OrdinalIgnoreCase) &&
                    string.Equals(g.SubCategory, subCategory, StringComparison.OrdinalIgnoreCase));
        }

        private string FormatName(string category, string? subCategory)
        {
            return string.IsNullOrWhiteSpace(subCategory)
                ? category
                : $"{category} - {subCategory}";
        }
        private bool IsValueInRange(decimal value, decimal? minValue, decimal? maxValue)
        {
            var minCheck = minValue == null || value >= minValue;
            var maxCheck = maxValue == null || value <= maxValue;
            return minCheck && maxCheck;
        }
    }
}
