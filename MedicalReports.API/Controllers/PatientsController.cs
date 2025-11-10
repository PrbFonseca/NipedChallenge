using MediatR;
using MedicalReports.Application.Dtos;
using MedicalReports.Application.Queries;
using Microsoft.AspNetCore.Mvc;

namespace MedicalReports.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PatientsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PatientDto>>> GetPatients()
        {
            var query = new GetAllPatientsQuery();

            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{patientId}/report")]
        public async Task<ActionResult<HealthReportDto>> GetPatientReport(int patientId)
        {
            var query = new GetPatientHealthReportQuery { PatientId = patientId};

            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
