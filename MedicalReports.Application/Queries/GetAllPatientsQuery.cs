using MediatR;
using MedicalReports.Application.Dtos;

namespace MedicalReports.Application.Queries
{
    public class GetAllPatientsQuery : IRequest<IEnumerable<PatientDto>>
    {
    }
}
