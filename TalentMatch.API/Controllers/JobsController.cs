using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TalentMatch.Application.DTOs;
using TalentMatch.Application.UseCases.Jobs.Commands;
using TalentMatch.Application.UseCases.Jobs.Queries;

namespace TalentMatch.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly IMediator mediator;

        public JobsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetJobById(Guid id)
        {
            var query = new GetJobByIdQuery(id);
            var result = await mediator.Send(query);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllJobs()
        {
            var query = new GetAllJobsQuery();
            var result = await mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateJob(CreateJobCommand command)
        {
            var jobId = await mediator.Send(command);
            return CreatedAtAction(nameof(CreateJobRequestModel), new { id = jobId }, null);
        }
    }
}
