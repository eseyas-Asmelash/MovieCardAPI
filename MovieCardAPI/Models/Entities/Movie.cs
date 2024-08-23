using System.Runtime.CompilerServices;

namespace MovieCardAPI.Models.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Rating { get; set; }
        public DateOnly ReleaseDate { get; set; }
        public string Description { get; set; }

        public Director Director { get; set; }
        public ICollection<Actor> Actors { get; set; }
        public ICollection<Genre> Genre { get; set; }
    }
}
