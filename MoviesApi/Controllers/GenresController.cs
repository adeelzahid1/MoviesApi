using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using MoviesApi.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoviesApi.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/genre")]
    public class GenresController : Controller
    {
        //private readonly IRepository repository;

        public GenresController()
        {
            //this.repository = repository;
        }

        [HttpGet]
        [Route("api/genre/GetGenres")]
        public async Task<ActionResult<List<Genre>>> GetGenres()
        {
            return new List<Genre>() { new Genre() {Id=1, Name="Movies" }, };
            //throw new NotImplementedException();

        }
 
        [HttpGet]
        [Route("api/genre/GetGenre/{id:int}")]
        public ActionResult<Genre> GetGenre(int id)
        {
            
            throw new NotImplementedException();
        }

        [HttpPost]
        public ActionResult SaveGenre()
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        public ActionResult UpdateGenre()
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        [Route("api/genre/DeleteGenre")]
        public ActionResult DeleteGenre()
        {
            throw new NotImplementedException();
        }




    }
}
