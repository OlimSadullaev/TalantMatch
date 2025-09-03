using MediatR;
using Microsoft.EntityFrameworkCore;
using TalentMatch.Application.Abstractions;
using TalentMatch.Application.DTOs;
using TalentMatch.Application.UseCases.JobApplications.Command;

namespace TalentMatch.Application.UseCases.JobApplications.Queries
{
    public class GetAllJobApplicationsQuery : IQuery<List<JobApplicationResponseModel>>
    {
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
