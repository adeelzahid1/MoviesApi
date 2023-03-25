using AutoMapper;
using MoviesApi.DTOs;
using MoviesApi.Entities;
using NetTopologySuite.Geometries;

namespace MoviesApi.Helpers
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile(GeometryFactory geometryFactory)
        {
            CreateMap<GenreDto, Genre>().ReverseMap();
            CreateMap<GenreCreationDto, Genre>();
            
            CreateMap<ActorDto, Actor>().ReverseMap();
            CreateMap<ActorCreationDto, Actor>()
                .ForMember(x => x.Picture, options => options.Ignore());

            CreateMap<MovieTheater, MovieTheaterDto>()
            .ForMember(x => x.Latitude, dto => dto.MapFrom(prop => prop.Location.Y))
            .ForMember(x => x.Latitude, dto => dto.MapFrom(prop => prop.Location.X));

            CreateMap<MovieTheaterCreationDto, MovieTheater>()
                .ForMember(x => x.Location, x => x.MapFrom( dto =>  
                    geometryFactory.CreatePoint(new Coordinate(dto.Longitude, dto.Latitude))
                ));
        }
    }
}
