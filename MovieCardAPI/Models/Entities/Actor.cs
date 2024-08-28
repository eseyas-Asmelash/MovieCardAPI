namespace MovieCardAPI.Models.Entities
{
    public class Actor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }

        // Navigation properties
        public ICollection<Movie> Movies { get; set; }
    }
}
