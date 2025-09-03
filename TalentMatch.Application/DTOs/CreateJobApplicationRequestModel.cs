using System.ComponentModel.DataAnnotations;

namespace TalentMatch.Application.DTOs
{
    public class CreateJobApplicationRequestModel
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        public string PhoneNumber { get; set; }
        public string LinkedIn { get; set; }
        public string CvFilePath { get; set; }

        [Required]
        public Guid JobId { get; set; }
    }
}
