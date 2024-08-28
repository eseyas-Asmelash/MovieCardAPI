namespace MovieCardAPI.Models.Entities
{
    public class ContactInformation
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        // Navigation property
        public int DirectorId { get; set; }
        public Director Director { get; set; }
    }
}
