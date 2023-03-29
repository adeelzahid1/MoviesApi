using MoviesApi.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesApi.Helpers;

namespace MoviesApi.DTOs
{
    public class MovieCreationDto
    {
        [StringLength(maximumLength: 75)]
        [Required]
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Trailer { get; set; }

        public bool InTheaters { get; set; }

        public DateTime ReleaseDate { get; set; }

        public IFormFile Poster { get; set; }

        [ModelBinder(BinderType = typeof(TypeBinder<List<int>>))]
        public List<int> GenresIds { get; set; }

        [ModelBinder(BinderType = typeof(TypeBinder<List<int>>))]
        public List<int> MovieTheatersIds { get; set; }


        [ModelBinder(BinderType = typeof(TypeBinder<List<MoviesActorsCreationDto>>))]
        public List<MoviesActorsCreationDto> Actors { get; set; }


        //public List<MoviesGenres> MoviesGenres { get; set; }

        //public List<MovieTheatersMovies> MovieTheatersMovies { get; set; }
    }
}
