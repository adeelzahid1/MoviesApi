using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Routing;
using MoviesApi.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
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
            int id = 0;
            //var myNumberList = new List<int> [1, 2, 3, 5, 6];
            int[] myNumberList = Enumerable.Range(1, 21).ToArray();

            foreach (var item in myNumberList)
            {
                if (item is 1 or 2 or 5 and <= 10 )
                {
                    id = id + item;
                }
            }
            return new List<Genre>() { new Genre() {Id=id, Name="Movies" }, };
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
