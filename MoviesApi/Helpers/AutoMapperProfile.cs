using AutoMapper;
using MoviesApi.DTOs;
using MoviesApi.Entities;
using NetTopologySuite.Geometries;
using System.Collections.Generic;

namespace MoviesApi.Helpers
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile(GeometryFactory geometryFactory)
        //public AutoMapperProfile()
        {
            CreateMap<GenreDto, Genre>().ReverseMap();
            CreateMap<GenreCreationDto, Genre>();
            
            CreateMap<ActorDto, Actor>().ReverseMap();
            CreateMap<ActorCreationDto, Actor>()
                .ForMember(x => x.Picture, options => options.Ignore());

            CreateMap<MovieTheater, MovieTheaterDto>()
            .ForMember(x => x.Latitude, dto => dto.MapFrom(prop => prop.Location.Y))
            .ForMember(x => x.Longitude, dto => dto.MapFrom(prop => prop.Location.X));

            CreateMap<MovieTheaterCreationDto, MovieTheater>()
                .ForMember(x => x.Location, x => x.MapFrom(dto =>
                    geometryFactory.CreatePoint(new Coordinate(dto.Longitude, dto.Latitude))
                ));

            CreateMap<MovieCreationDto, Movie>()
            .ForMember(x => x.Poster, options => options.Ignore())
            .ForMember(x => x.MoviesGenres, options => options.MapFrom(MapMoviesGenres))
            .ForMember(x => x.MovieTheatersMovies, options => options.MapFrom(MapMovieTheatersGenres))
            .ForMember(x => x.MoviesActors, options => options.MapFrom(MapMoviesActors))
            ;
        }

        private List<MoviesGenres> MapMoviesGenres(MovieCreationDto moviesCreationDto, Movie movie)
        {
            var result = new List<MoviesGenres>();
            if(moviesCreationDto.GenresIds is null) { return result; }
            
            foreach (var id in moviesCreationDto.GenresIds)
            {
                result.Add(new MoviesGenres() { GenreId = id} );
            }

            return result;

        }

        private List<MovieTheatersMovies> MapMovieTheatersGenres(MovieCreationDto moviesCreationDto, Movie movie)
        {
            var result = new List<MovieTheatersMovies>();
            if (moviesCreationDto.MovieTheatersIds is null) { return result; }

            foreach (var id in moviesCreationDto.MovieTheatersIds)
            {
                result.Add(new MovieTheatersMovies() { MovieTheaterId = id });
            }

            return result;

        }

        private List<MoviesActors> MapMoviesActors(MovieCreationDto moviesCreationDto, Movie movie)
        {
            var result = new List<MoviesActors>();
            if (moviesCreationDto.Actors is null) { return result; }

            foreach (var actor in moviesCreationDto.Actors)
            {
                result.Add(new MoviesActors() { ActorId =  actor.Id, Character = actor.Character });
            }

            return result;

        }




    }
}
