using AutoMapper;
using MediatR;
using MedicalReports.Application.Dtos;
using MedicalReports.Application.Interfaces;
using MedicalReports.Application.Queries;
using Microsoft.EntityFrameworkCore;

namespace MedicalReports.Application.Handlers
{
    public class GetAllPatientsQueryHandler : IRequestHandler<GetAllPatientsQuery, IEnumerable<PatientDto>>
    {
        private readonly IAppDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAllPatientsQueryHandler(IAppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PatientDto>> Handle(GetAllPatientsQuery request, CancellationToken cancellationToken)
        {
            var patients = await _dbContext.Patients
                .Include(e => e.BloodWork)
                .Include(e => e.Questionnaires)
                .ToListAsync(cancellationToken);

            return _mapper.Map<IEnumerable<PatientDto>>(patients);
        }
    }
}
