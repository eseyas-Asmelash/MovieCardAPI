namespace MovieCardAPI.Models.DTOs
{
    public record DirectorDto(int Id, string Name, DateTime DateOfBirth, ContactInformationDto ContactInformation);
    public record ActorDto(int Id, string Name, DateTime DateOfBirth);
    public record GenreDto(int Id, string Name);
    public record ContactInformationDto(int Id, string Email, string PhoneNumber);

    public class MovieDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double Rating { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Description { get; set; }
    }


}
