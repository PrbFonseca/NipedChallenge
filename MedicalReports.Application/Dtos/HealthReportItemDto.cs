using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalReports.Application.Dtos
{
    public class HealthReportItemDto
    {
        public string Name { get; set; } = string.Empty;  
        public string Value { get; set; } = string.Empty;
        public string? Note { get; set; }
        public string Status { get; set; } = string.Empty;  
    }
}
