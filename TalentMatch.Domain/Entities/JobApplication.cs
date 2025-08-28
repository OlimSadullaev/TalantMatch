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

        // Candidate info
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string LinkedIn { get; set; }
        public string CV { get; set; }

        // Relation
        public Guid JobId { get; set; }
        public Job Job { get; set; }
    }
}
