using MedicalReports.Core.Common;
using MedicalReports.Core.Enums;
using System.Collections.Generic;

namespace MedicalReports.Core.Entities
{
    public class Guideline : EntityBase
    {
        public string Category { get; set; } = string.Empty;
        public string? SubCategory { get; set; }
        public MatchingType MatchingType { get; set; }
        public string? Unit { get; set; }
        public bool IsActive { get; set; } = true;        
        public List<GuidelineItem> GuidelineItems { get; set; } = new List<GuidelineItem>();
    }
}
