using RecruitAI.Domain.Enums;
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
        public string KeyResponsibilities { get; set; } = string.Empty;
        public List<string> Qualifications { get; set; } = new();
        public string About_Us { get; set; } = string.Empty;
        public string Benefits { get; set; }
        public string Location { get; set; }
        public double FitScore { get; set; }

        public DateTime PostedDate { get; set; }
        public Guid RecruiterId { get; set; }
        public UserRole User { get; set; }

        // Navigation
        public ICollection<JobApplication> Applications { get; set; }
    }
}
