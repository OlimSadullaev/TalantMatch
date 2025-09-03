using MediatR;
using Microsoft.EntityFrameworkCore;
using RecruitAI.Domain.Entities;
using TalentMatch.Application.Abstractions;
using TalentMatch.Application.DTOs;

namespace TalentMatch.Application.UseCases.JobApplications.Command
{
    public class CreateJobApplicationCommand : ICommand<Unit>
    {
        public CreateJobApplicationRequestModel jobApplication { get; set; }

        public CreateJobApplicationCommand(CreateJobApplicationRequestModel jobApplication)
        {
            this.jobApplication = jobApplication;
        }
    }

    public class CreateJobApplicationCommandHandler
    : ICommandHandler<CreateJobApplicationCommand, Unit>
    {
        private readonly IApplicationDbContext context;

        public CreateJobApplicationCommandHandler(IApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<Unit> Handle(CreateJobApplicationCommand request, CancellationToken cancellationToken)
        {
            var jobApplication = new JobApplication
            {
                Id = Guid.NewGuid(),
                FirstName = request.jobApplication.FirstName,
                LastName = request.jobApplication.LastName,
                Email = request.jobApplication.Email,
                PhoneNumber = request.jobApplication.PhoneNumber,
                LinkedIn = request.jobApplication.LinkedIn,
                CV = request.jobApplication.CvFilePath,
                JobId = request.jobApplication.JobId
            };

            await context.JobApplications.AddAsync(jobApplication, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
