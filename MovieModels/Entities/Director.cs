namespace MovieModels.Entities
{
    public class Director
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime DateOfBirth { get; set; }

        // Navigation properties
        public ICollection<Movie> Movies { get; set; }
        public ContactInformation ContactInfo { get; set; }
    }
}
