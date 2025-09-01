using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentMatch.Application.Abstractions;
using TalentMatch.Application.DTOs;

namespace TalentMatch.Application.UseCases.Jobs.Commands
{
    public class UpdateJobCommand : ICommand<Unit>
    {
        public UpdateJobRequestModel job { get; set; }

        public UpdateJobCommand(UpdateJobRequestModel job)
        {
            this.job = job;
        }
    }
    
    public class UpdateJobCommandHandler : ICommandHandler<UpdateJobCommand, Unit>
    {
        private readonly IApplicationDbContext context;
        private readonly IMapper mapper;

        public UpdateJobCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateJobCommand request, CancellationToken cancellationToken)
        {
            var job = await context.Jobs
                .FirstOrDefaultAsync(j => j.Id == request.job.Id, cancellationToken);

            if (job == null)
                throw new KeyNotFoundException("Job not found");

            // Update fields
            job.Title = request.job.Title;
            job.KeyResponsibilities = request.job.KeyResponsibilities;
            job.Qualifications = request.job.Qualifications;
            job.About_Us = request.job.About_Us;
            job.Benefits = request.job.Benefits;
            job.Location = request.job.Location;

            await context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
