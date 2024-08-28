namespace MovieCardAPI.Models.Entities
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Navigation properties
        public ICollection<Movie> Movies { get; set; }
    }
}
