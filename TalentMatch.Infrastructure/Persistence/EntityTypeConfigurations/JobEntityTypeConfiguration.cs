using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecruitAI.Domain.Entities;

namespace TalentMatch.Infrastructure.Persistence.EntityTypeConfigurations
{
    public class JobEntityTypeConfiguration : IEntityTypeConfiguration<Job>
    {
        public void Configure(EntityTypeBuilder<Job> builder)
        {
            builder.ToTable("Jobs");

            builder.HasKey(j => j.Id);

            builder.Property(j => j.Title)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(j => j.KeyResponsibilities)
                .IsRequired();

            builder.Property(j => j.Qualifications)
                .HasConversion(
                    v => string.Join(";", v),
                    v => v.Split(";", StringSplitOptions.RemoveEmptyEntries).ToList()
                );

            builder.Property(j => j.About_Us)
                   .HasMaxLength(2000);

            builder.Property(j => j.Benefits)
                   .HasMaxLength(2000);

            builder.Property(j => j.Location)
                   .HasMaxLength(250);

            builder.Property(j => j.FitScore)
                   .HasPrecision(5, 2);

            builder.Property(j => j.PostedDate)
                   .IsRequired();

            // One Job -> Many Applications
            builder.HasMany(j => j.Applications)
                   .WithOne(a => a.Job)
                   .HasForeignKey(a => a.JobId);
        }
    }
}
