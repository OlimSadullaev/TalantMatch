using RecruitAI.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitAI.Domain.Entities
{
    public class JobApplication
    {
        public Guid Id { get; set; }
        public Guid CandidateId { get; set; }
        public UserRole User{ get; set; }
        public Guid JobId { get; set; }
        public Job Job { get; set; }

        public string ResumeFilePath { get; set; } = string.Empty;
        public string ExtractedSkills { get; set; } = string.Empty;
        public string ExtractedExperience { get; set; } = string.Empty;

        public double FitScore { get; set; }
        public DateTime AppliedAt { get; set; } = DateTime.UtcNow;
    }
}
