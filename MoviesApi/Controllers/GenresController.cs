using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using MoviesApi.DTOs;
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
    [ApiController]
    public class GenresController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        //private readonly IRepository repository;

        public GenresController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
            //this.repository = repository;
        }

        [HttpGet]
        [Route("GetGenres")]
        public async Task<ActionResult<List<GenreDto>>> GetGenres()
        {
                var genres = await context.Genres.OrderBy(x => x.Name).ToListAsync();
                return mapper.Map<List<GenreDto>>(genres);      
            //int id = 0;
            //int[] myNumberList = Enumerable.Range(1, 21).ToArray();

            //foreach (var item in myNumberList)
            //{
            //    if (item is 1 or 2 or 5 and <= 10 )
            //    {
            //        id = id + item;
            //    }
            //}
        }
 
        [HttpGet]
        //[Route("GetGenre/{id:int}", Name ="getGenre")]
        [Route("GetGenre/{id:int}")]
        public async Task<ActionResult<GenreDto>> GetGenre(int id)
        {
            var genre = await context.Genres.FirstOrDefaultAsync(x => x.Id == id);
            if (genre is null)
            {
                return NotFound();
            }
            return mapper.Map<GenreDto>(genre);
        }

        [HttpPost]
        [Route("SaveGenre")]
        public async Task<ActionResult> SaveGenre([FromBody] GenreCreationDto genreCreationDto)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            var genre = mapper.Map<Genre>(genreCreationDto);
            context.Genres.Add(genre);
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut]
        public ActionResult UpdateGenre()
        {
            throw new NotImplementedException();
        }


        [HttpPut]
        [Route("EditGenre/{id:int}")]
        public async Task<ActionResult> EditGenre(int id, [FromBody]GenreCreationDto genreDto)
        {
            try
            {
                var genre = mapper.Map<Genre>(genreDto);
                genre.Id = id;
                //genre.Name = genre.Name;
                context.Entry(genre).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {

                throw;
            }

            return NoContent();

        }


        [HttpDelete]
        [Route("DeleteGenre/{id:int}")]
        public ActionResult DeleteGenre()
        {
            throw new NotImplementedException();
        }




    }
}
