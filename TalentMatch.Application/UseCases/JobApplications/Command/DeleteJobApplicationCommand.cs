using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentMatch.Application.Abstractions;

namespace TalentMatch.Application.UseCases.JobApplications.Command
{
    public class DeleteJobApplicationCommand : ICommand<Unit>
    {
        public Guid Id { get; set; }

        public DeleteJobApplicationCommand(Guid id)
        {
            Id = id;
        }
    }
    public class DeleteJobApplicationCommandHandler
        : ICommandHandler<DeleteJobApplicationCommand, Unit>
    {
        private readonly IApplicationDbContext context;

        public DeleteJobApplicationCommandHandler(IApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<Unit> Handle(DeleteJobApplicationCommand request, CancellationToken cancellationToken)
        {
            var entity = await context.JobApplications
                .FirstOrDefaultAsync(j => j.Id == request.Id, cancellationToken);

            if (entity == null)
                throw new KeyNotFoundException("Job application not found");

            context.JobApplications.Remove(entity);
            await context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
