namespace MovieCardAPI.Models.Entities
{
    public class Actor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateOnly MyProperty { get; set; }
        public ICollection<Movie> Movies { get; set; }
    }
}
