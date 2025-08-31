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
    public class GetAllJobsQuery : IQuery<List<Job>>
    {
    }

    public class GetAllJobsQueryHandler : IQueryHandler<GetAllJobsQuery, List<Job>>
    {
        private readonly IApplicationDbContext _dbContext;

        public GetAllJobsQueryHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Job>> Handle(GetAllJobsQuery query, CancellationToken cancellationToken)
        {
            var jobs = await _dbContext.Jobs
                .OrderByDescending(j => j.PostedDate)
                .ToListAsync(cancellationToken);

            return jobs;
        }
    }
}
