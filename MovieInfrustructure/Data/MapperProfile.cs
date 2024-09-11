using AutoMapper;
using MovieShared.DTOs;
using MovieModels.Entities;

namespace MovieInfrustructure.Data
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
