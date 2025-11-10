using MedicalReports.Core.Common;

namespace MedicalReports.Core.Entities
{
    public class PatientBloodWork : EntityBase
    {
        public int PatientId { get; set; }

        public string Category { get; set; } = string.Empty;
        public string? SubCategory { get; set; }
        public decimal Value { get; set; }
        public string Unit { get; set; } = string.Empty;
        public DateTime MeasurementDate { get; set; } = DateTime.UtcNow;

        public Patient? Patient { get; set; }
    }
}
