using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalReports.Application.Dtos
{
    public class HealthReportDto
    {
        public int PatientId { get; set; }
        public string PatientName { get; set; } = string.Empty;
        public DateTime ReportDate { get; set; }

        public List<HealthReportItemDto> ReportItems { get; set; } = new();
    }
}
