using MedicalReports.Core.Enums;

namespace MedicalReports.Application.Dtos
{
    public class PatientDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public DateTime DateOfBirth { get; set; }

        public string Gender { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public List<PatientBloodWorkDto> BloodWork { get; set; } = new();
        public List<PatientQuestionnaireDto> Questionnaires { get; set; } = new();
    }
}
