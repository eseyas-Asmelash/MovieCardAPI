using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieModels.Entities;

namespace MovieShared.DTOs
{

    
        public record DirectorDto(string Name, DateTime DateOfBirth, ContactInformationDto ContactInformation);
        public record ActorDto(string Name, DateTime DateOfBirth);
        public record GenreDto(string Name);
        public record ContactInformationDto(string Email, string PhoneNumber);

        public record MovieDto
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public double Rating { get; set; }
            public DateTime ReleaseDate { get; set; }
            public string Description { get; set; }
        }
        public class CreateMovieDto
        {
            public string Title { get; set; }
            public double Rating { get; set; }
            public DateTime ReleaseDate { get; set; }
            public string Description { get; set; }
            public DirectorDto Director { get; set; }
            public IEnumerable<GenreDto> Genres { get; set; }
            public IEnumerable<ActorDto> Actors { get; set; }

        }
        public class UpdateMovieDto
        {
            public string Title { get; set; }
            public double Rating { get; set; }
            public DateTime ReleaseDate { get; set; }
            public string Description { get; set; }
            public DirectorDto Director { get; set; }
            public IEnumerable<GenreDto> Genres { get; set; }
            public IEnumerable<ActorDto> Actors { get; set; }

        }
    
}
