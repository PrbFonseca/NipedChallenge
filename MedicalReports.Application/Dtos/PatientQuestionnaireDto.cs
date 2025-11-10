using MedicalReports.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalReports.Application.Dtos
{
    public class PatientQuestionnaireDto
    {
        public string Category { get; set; } = string.Empty;
        public string? SubCategory { get; set; }
        public string ResponseValue { get; set; } = string.Empty;

        public decimal? NumericValue { get; set; }

        public DateTime ResponseDate { get; set; } = DateTime.UtcNow;
    }
}
