using RecruitAI.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalentMatch.Application.DTOs
{
    public class CreateJobRequestModel
    {
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; }

        [Required]
        public string KeyResponsibilities { get; set; }

        [Required]
        public List<string> Qualifications { get; set; } = new();

        public string About_Us { get; set; }
        public string Benefits { get; set; }
        public string Location { get; set; }
        public double FitScore { get; set; }
        public DateTime PostedDate { get; set; } = DateTime.UtcNow;

        [Required]
        public Guid RecruiterId { get; set; }

        public UserRole User { get; set; } = UserRole.Recruiter;
    }
}
