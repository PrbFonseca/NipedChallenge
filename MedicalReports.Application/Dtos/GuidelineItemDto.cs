using MedicalReports.Core.Entities;
using MedicalReports.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalReports.Application.Dtos
{
    public class GuidelineItemDto
    {
        public int Id { get; set; }
        public string Status { get; set; } = string.Empty;
        public decimal? MinValue { get; set; }
        public decimal? MaxValue { get; set; }
        public string? TextualValue { get; set; }
    }
}
