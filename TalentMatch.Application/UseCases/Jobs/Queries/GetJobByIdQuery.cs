using Microsoft.EntityFrameworkCore;
using RecruitAI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentMatch.Application.Abstractions;

namespace TalentMatch.Application.UseCases.Jobs.Queries
{
    public class GetJobByIdQuery : IQuery<Job>
    {
        public Guid JobId { get; }

        public GetJobByIdQuery(Guid jobId)
        {
            JobId = jobId;
        }
    }

    public class GetJobByIdQueryHandler : IQueryHandler<GetJobByIdQuery, Job>
    {
        private readonly IApplicationDbContext _dbContext;

        public GetJobByIdQueryHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Job> Handle(GetJobByIdQuery request, CancellationToken cancellationToken)
        {
            var job = await _dbContext.Jobs
                .Include(j => j.Applications)
                .FirstOrDefaultAsync(j => j.Id == request.JobId, cancellationToken);

            return job;
        }
    }
}
