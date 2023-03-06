using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using MoviesApi.Entities;
using MoviesApi.Services;
using System.Collections.Generic;

namespace MoviesApi.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/genre")]
    public class GenresController
    {
        private readonly IRepository repository;

        public GenresController(IRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        [Route("api/genre/GetGenres")]
        public List<Genre> GetGenres()
        {
            return repository.getGenres();
        }

        [HttpGet]
        [Route("api/genre/GetGenre/{id:int}")]
        public Genre GetGenre(int id)
        {
            var genre = repository.getGenre(id);
            if(genre is null) { }
            return genre;
        }

        [HttpPost]
        public void SaveGenre()
        {

        }

        [HttpPut]
        public void UpdateGenre()
        {

        }

        [HttpDelete]
        [Route("api/genre/DeleteGenre")]
        public void DeleteGenre()
        {

        }




    }
}
