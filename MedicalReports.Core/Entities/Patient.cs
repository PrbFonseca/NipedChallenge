using MedicalReports.Core.Common;
using MedicalReports.Core.Enums;

namespace MedicalReports.Core.Entities
{
    public class Patient : EntityBase
    {
        public string Name { get; set; } = string.Empty;

        public DateTime DateOfBirth { get; set; }

        public Gender Gender { get; set; }

        public string Email { get; set; } = string.Empty;

        public List<PatientBloodWork> BloodWork { get; set; } = new List<PatientBloodWork>();
        public List<PatientQuestionnaire> Questionnaires { get; set; } = new List<PatientQuestionnaire>();

    }
}
