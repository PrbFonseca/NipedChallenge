using AutoMapper;
using MediatR;
using MedicalReports.Application.Dtos;
using MedicalReports.Application.Interfaces;
using MedicalReports.Application.Queries;
using Microsoft.EntityFrameworkCore;

namespace MedicalReports.Application.Handlers
{
    public class GetGuidelinesQueryHandler : IRequestHandler<GetGuidelinesQuery, IEnumerable<GuidelineDto>>
    {
        private readonly IAppDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetGuidelinesQueryHandler(IAppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GuidelineDto>> Handle(GetGuidelinesQuery request, CancellationToken cancellationToken)
        {
            var query = _dbContext.Guidelines
                    .Include(g => g.GuidelineItems)
                    .AsQueryable();

            if (!string.IsNullOrEmpty(request.Category))
            {
                query = query.Where(g => g.Category == request.Category);
            }

            if (request.IsActive.HasValue)
            {
                query = query.Where(g => g.IsActive == request.IsActive.Value);
            }

            var guidelines = await query.ToListAsync(cancellationToken);

            return _mapper.Map<List<GuidelineDto>>(guidelines);
        }
    }
}
