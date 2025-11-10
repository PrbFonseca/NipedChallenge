using MedicalReports.Core.Common;

namespace MedicalReports.Core.Entities
{
    public class PatientQuestionnaire : EntityBase
    {
        public int PatientId { get; set; }

        public string Category { get; set; } = string.Empty;
        public string? SubCategory { get; set; }
        public string ResponseValue { get; set; } = string.Empty;

        public decimal? NumericValue { get; set; }

        public DateTime ResponseDate { get; set; } = DateTime.UtcNow;

        public Patient? Patient { get; set; }

        public void SetResponse(string value)
        {
            ResponseValue = value;
            NumericValue = decimal.TryParse(value, out var numericValue) ? numericValue : null;
        }
    }
}
