using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecruitAI.Domain.Entities;

namespace TalentMatch.Infrastructure.Persistence.EntityTypeConfigurations
{
    public class JobApplicationEntityTypeConfiguration : IEntityTypeConfiguration<JobApplication>
    {
        public void Configure(EntityTypeBuilder<JobApplication> builder)
        {
            builder.ToTable("JobApplications");

            builder.HasKey(ja => ja.Id);

            // Candidate Info
            builder.Property(ja => ja.FirstName)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(ja => ja.LastName)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(ja => ja.Email)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(ja => ja.PhoneNumber)
                   .HasMaxLength(20);

            builder.Property(ja => ja.LinkedIn)
                   .HasMaxLength(250);

            builder.Property(ja => ja.CV)
                   .HasMaxLength(500); // Path or file name

            // Relation to Job
            builder.HasOne(ja => ja.Job)
                   .WithMany(j => j.Applications)   // add ICollection<JobApplication> Applications in Job
                   .HasForeignKey(ja => ja.JobId);
        }
    }
}
