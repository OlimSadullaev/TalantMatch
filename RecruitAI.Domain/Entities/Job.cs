using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitAI.Domain.Entities
{
    public class Job
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string RequiredSkills { get; set; } = string.Empty; // comma-separated or JSON array
        public int MinExperience { get; set; }
        public string Location { get; set; } = string.Empty;
        public decimal Salary { get; set; }
        public double FitScoreForHr { get; set; }
        public Guid RecruiterId { get; set; }
        public User Recruiter { get; set; }

        // Navigation
        public ICollection<JobApplication> Applications { get; set; }
    }
}
