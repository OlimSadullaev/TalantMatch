namespace TalentMatch.Application.DTOs
{
    public class UpdateJobApplicationRequestModel
    {
        public Guid Id { get; set; }
        public string PhoneNumber { get; set; }
        public string LinkedIn { get; set; }
        public string CV { get; set; }
    }
}
