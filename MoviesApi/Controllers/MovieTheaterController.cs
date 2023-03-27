using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesApi.DTOs;
using MoviesApi.Entities;
using MoviesApi.Helpers;
using MoviesApi.Migrations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesApi.Controllers
{
    [Route("api/movietheaters")]
    [ApiController]
    public class MovieTheaterController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public MovieTheaterController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("GetMovieTheaters")]
        public async Task<ActionResult<List<MovieTheaterDto>>> GetMovieTheaters()
        {
            var theater = await context.MovieTheaters.ToListAsync();
            return mapper.Map<List<MovieTheaterDto>>(theater);
        }

        [HttpGet]
        [Route("GetMovieTheater/{id:int}")]
        public async Task<ActionResult<MovieTheaterCreationDto>> GetMovieTheater(int id)
        {
            var movieTheater = await context.MovieTheaters.FirstOrDefaultAsync(x => x.Id == id);
            if (movieTheater is null)
            {
                return NoContent();
            }
            return mapper.Map<MovieTheaterCreationDto>(movieTheater);
        }

        [HttpPost]
        [Route("SaveMovieTheater")]
        public async Task<ActionResult> SaveMovieTheater(MovieTheaterCreationDto movieCreationDto)
        {
            //var movieTheater = new MovieTheater();
            //movieTheater.Name = movieCreationDto.Name;
            //movieTheater.Location = new Point(movieCreationDto.Latitude, movieCreationDto.Longitude) { SRID = 4326 };
            //new Point(-122.4194155, 37.7749295) { SRID = 4326 };
            try
            {
                var movieTheater = mapper.Map<MovieTheater>(movieCreationDto);
                context.Add(movieTheater);
                await context.SaveChangesAsync();
                return NoContent();
            }
            catch (System.Exception ex)
            {
                var exp = ex.Message;
                throw;
            }
        }

        [HttpPut]
        [Route("UpdateMovieTheater/{id:int}")]
        public async Task<ActionResult> UpdateMovieTheater(int id, MovieTheaterCreationDto movieCreationDto)
        {
            var movie = await context.MovieTheaters.FirstOrDefaultAsync(x => x.Id == id);
            if (movie is null)
            {
                return NoContent();
            }
            movie = mapper.Map(movieCreationDto, movie);
            await context.SaveChangesAsync();
            return NoContent();

        }

        [HttpDelete]
        [Route("DeleteMovieTheater/{id:int}")]
        public async Task<ActionResult> DeleteMovieTheater(int id)
        {
            var movieTheater = await context.MovieTheaters.FirstOrDefaultAsync(x => x.Id == id);
            if (movieTheater is null)
                return NotFound();

            context.Remove(movieTheater);
            await context.SaveChangesAsync();

            return NoContent();
        }












    }
}
