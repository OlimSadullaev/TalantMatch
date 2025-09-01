using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentMatch.Application.Abstractions;

namespace TalentMatch.Application.UseCases.Jobs.Commands
{
    public class DeleteJobCommand : ICommand<Unit>
    {
        public Guid JobId { get; set; }

        public DeleteJobCommand(Guid jobId)
        {
            JobId = jobId;
        }
    }

    public class DeleteJobCommandHandler : ICommandHandler<DeleteJobCommand, Unit>
    {
        private readonly IApplicationDbContext context;

        public DeleteJobCommandHandler(IApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<Unit> Handle(DeleteJobCommand request, CancellationToken cancellationToken)
        {
            var job = await context.Jobs
                .FirstOrDefaultAsync(j => j.Id == request.JobId, cancellationToken);

            if (job == null)
                throw new KeyNotFoundException("Job not found");

            context.Jobs.Remove(job);
            await context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
