using AutoMapper;
using MoviesApi.DTOs;
using MoviesApi.Entities;

namespace MoviesApi.Helpers
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<GenreDto, Genre>().ReverseMap();
            CreateMap<GenreCreationDto, Genre>();
            
            CreateMap<ActorDto, Actor>().ReverseMap();
            CreateMap<ActorCreationDto, Actor>()
                .ForMember(x => x.Picture, options => options.Ignore());




        }
    }
}
