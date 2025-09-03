using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalentMatch.Application.UseCases.JobApplication
{
    public class UpdateJobApplicationRequestModel
    {
        public Guid Id { get; set; }
        public string PhoneNumber { get; set; }
        public string LinkedIn { get; set; }
        public string CV { get; set; }
    }
}
