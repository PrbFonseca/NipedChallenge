using MediatR;
using MedicalReports.Application.Dtos;

namespace MedicalReports.Application.Queries
{
    public class GetPatientHealthReportQuery : IRequest<HealthReportDto>
    {
        public int PatientId { get; set; }
    }
}
