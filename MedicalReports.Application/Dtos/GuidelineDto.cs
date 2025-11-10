using MedicalReports.Core.Entities;
using MedicalReports.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalReports.Application.Dtos
{
    public class GuidelineDto
    {
        public int Id { get; set; }
        public string Category { get; set; } = string.Empty;
        public string? SubCategory { get; set; }
        public string MatchingType { get; set; } = string.Empty;
        public string? Unit { get; set; }
        public bool IsActive { get; set; }
        public List<GuidelineItemDto> GuidelineItems { get; set; } = new();
    }
}
