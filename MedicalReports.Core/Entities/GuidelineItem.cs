using MedicalReports.Core.Common;
using MedicalReports.Core.Enums;

namespace MedicalReports.Core.Entities
{
    public class GuidelineItem : EntityBase
    {
        public HealthStatus Status { get; set; }
        public decimal? MinValue { get; set; }
        public decimal? MaxValue { get; set; }
        public string? TextualValue { get; set; }
        public int GuidelineId { get; set; }
        public Guideline? Guideline { get; set; }
    }
}


