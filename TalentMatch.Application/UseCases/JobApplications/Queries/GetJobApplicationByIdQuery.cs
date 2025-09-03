using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentMatch.Application.Abstractions;
using TalentMatch.Application.DTOs;

namespace TalentMatch.Application.UseCases.JobApplications.Queries
{
    public class GetJobApplicationByIdQuery : IQuery<JobApplicationResponseModel>
    {
        public Guid Id { get; set; }

        public GetJobApplicationByIdQuery(Guid id)
        {
            Id = id;
        }
    }

    public class GetJobApplicationByIdQueryHandler
        : IQueryHandler<GetJobApplicationByIdQuery, JobApplicationResponseModel>
    {
        private readonly IApplicationDbContext context;
        private readonly IMapper mapper;

        public GetJobApplicationByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<JobApplicationResponseModel> Handle(GetJobApplicationByIdQuery request, CancellationToken cancellationToken)
        {
            var application = await context.JobApplications
                .AsNoTracking()
                .ProjectTo<JobApplicationResponseModel>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(j => j.Id == request.Id, cancellationToken);

            if (application == null)
                throw new KeyNotFoundException("Job application not found");

            return application;
        }
    }
}
