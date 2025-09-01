using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalentMatch.Application.DTOs
{
    public class UpdateJobRequestModel
    {
        [Required]
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
    }
}
