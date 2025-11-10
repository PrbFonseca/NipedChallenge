using MedicalReports.Core.Entities;

namespace MedicalReports.Application.Dtos
{
    public class PatientBloodWorkDto
    {
        public string Category { get; set; } = string.Empty;
        public string? SubCategory { get; set; }
        public decimal Value { get; set; }
        public string Unit { get; set; } = string.Empty;
        public DateTime MeasurementDate { get; set; } = DateTime.UtcNow;
    }
}
