using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
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
        private readonly ApplicationDbContext context;

        //private readonly IRepository repository;

        public GenresController(ApplicationDbContext context)
        {
            this.context = context;
            //this.repository = repository;
        }

        [HttpGet]
        [Route("GetGenres")]
        public async Task<ActionResult<List<Genre>>> GetGenres()
        {
            int id = 0;
            int[] myNumberList = Enumerable.Range(1, 21).ToArray();

            foreach (var item in myNumberList)
            {
                if (item is 1 or 2 or 5 and <= 10 )
                {
                    id = id + item;
                }
            }
            return await context.Genres.ToListAsync();

        }
 
        [HttpGet]
        [Route("api/genre/GetGenre/{id:int}")]
        public ActionResult<Genre> GetGenre(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [Route("SaveGenre")]
        public async Task<ActionResult> SaveGenre([FromBody] Genre genre)
        {
            context.Genres.Add(genre);
            await context.SaveChangesAsync();
            return NoContent();
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
