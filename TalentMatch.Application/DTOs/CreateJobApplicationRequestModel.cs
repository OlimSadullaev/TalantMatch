namespace TalentMatch.Application.DTOs
{
    public class CreateJobApplicationRequestModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string LinkedIn { get; set; }
        public string CV { get; set; }
        public Guid JobId { get; set; }
    }
}
