using MediatR;
using MedicalReports.Application.Dtos;
using MedicalReports.Core.Entities;

namespace MedicalReports.Application.Queries
{
    public class GetGuidelinesQuery : IRequest<IEnumerable<GuidelineDto>>
    {
        public string? Category { get; set; }
        public bool? IsActive { get; set; }
    }
}
