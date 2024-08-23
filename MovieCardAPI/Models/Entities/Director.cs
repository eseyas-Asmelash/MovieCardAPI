namespace MovieCardAPI.Models.Entities
{
    public class Director
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public ICollection<Movie> Movies { get; set; }
        public ContactInformation ContactInfo { get; set; }
    }
}
