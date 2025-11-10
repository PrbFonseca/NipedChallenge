using MediatR;
using MedicalReports.Application.Dtos;
using MedicalReports.Application.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedicalReports.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GuidelinesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GuidelinesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<GuidelineDto>>> GetGuidelines(
            [FromQuery] string? category = null,
            [FromQuery] bool? isActive = null)
        {
            var query = new GetGuidelinesQuery
            {
                Category = category,
                IsActive = isActive
            };

            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
