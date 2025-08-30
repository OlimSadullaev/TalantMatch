using Microsoft.EntityFrameworkCore;
using RecruitAI.Domain.Entities;

namespace TalentMatch.Application.Abstractions
{
    public interface IApplicationDbContext
    {
        DbSet<Job> Jobs { get; set; }
        DbSet<JobApplication> JobApplications { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
