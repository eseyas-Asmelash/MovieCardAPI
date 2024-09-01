using AutoMapper;
using MovieCardAPI.Models.DTOs;
using MovieCardAPI.Models.Entities;

namespace MovieCardAPI.Data
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Movie, MovieDto>().ReverseMap();
            CreateMap<CreateMovieDto, Movie>();
            CreateMap<UpdateMovieDto, Movie>();
            CreateMap<Director, DirectorDto>().ReverseMap();
            CreateMap<Actor, ActorDto>().ReverseMap();
            CreateMap<Genre, GenreDto>().ReverseMap();
            CreateMap<ContactInformation, ContactInformationDto>().ReverseMap();
        }
    }


}
