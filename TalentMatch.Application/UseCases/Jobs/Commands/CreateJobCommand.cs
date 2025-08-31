using MediatR;
using Microsoft.EntityFrameworkCore;
using RecruitAI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentMatch.Application.Abstractions;
using TalentMatch.Application.DTOs;

namespace TalentMatch.Application.UseCases.Jobs.Commands
{
    public class CreateJobCommand : ICommand<Unit>
    {
        public CreateJobRequest Job { get; set; }   
    }

    public class CreateJobCommandHandler : ICommandHandler<CreateJobCommand, Unit>
    {
        private readonly IApplicationDbContext context;
        public CreateJobCommandHandler(IApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<Unit> Handle(CreateJobCommand request, CancellationToken cancellationToken)
        {
            var job = new Job
            {
                Id = Guid.NewGuid(),
                Title = request.Job.Title,
                KeyResponsibilities = request.Job.KeyResponsibilities,
                Qualifications = request.Job.Qualifications,
                About_Us = request.Job.About_Us,
                Benefits = request.Job.Benefits,
                Location = request.Job.Location,
                PostedDate = DateTime.UtcNow,
                RecruiterId = request.Job.RecruiterId,
                User = request.Job.User
            };

            await context.Jobs.AddAsync(job, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
