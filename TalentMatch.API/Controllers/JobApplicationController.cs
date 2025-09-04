using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TalentMatch.Application.UseCases.JobApplications.Command;
using TalentMatch.Application.UseCases.JobApplications.Queries;

namespace TalentMatch.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobApplicationController : ControllerBase
    {
        private readonly IMediator mediator;

        public JobApplicationController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateJobApplicationCommand command)
        {
            if (command == null || command == null)
                return BadRequest("Invalid job application data");

            await mediator.Send(command);
            return Ok("Job application created successfully");
        }

        [HttpGet]
        public async Task<ActionResult<List<GetAllJobApplicationsQuery>>> GetAll()
        {
            var result = await mediator.Send(new GetAllJobApplicationsQuery());
            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<GetJobApplicationByIdQuery>> GetById(Guid id)
        {
            var result = await mediator.Send(new GetJobApplicationByIdQuery(id));
            return Ok(result);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await mediator.Send(new DeleteJobApplicationCommand(id));
            return Ok("Job application deleted successfully");
        }
    }
}
