using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MoviesApi.DTOs;
using MoviesApi.Entities;
using MoviesApi.Helpers;
using System.Threading.Tasks;

namespace MoviesApi.Controllers
{
    [Route("api/movies")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        private readonly IFileStorageService fileStorageService;
        private string container = "movies";
        public MoviesController(ApplicationDbContext context, IMapper mapper, IFileStorageService fileStorageService)
        {
            this.context = context;
            this.mapper = mapper;
            this.fileStorageService = fileStorageService;
        }


        [HttpPost]
        [Route("SaveMovie")]
        public async Task<ActionResult> SaveMovie([FromForm] MovieCreationDto movieCreationDto)
        {
            var movie = mapper.Map<Movie>(movieCreationDto);
            if (movieCreationDto.Poster is not null)
            {
                movie.Poster = await fileStorageService.SaveFile(container, movieCreationDto.Poster);

            }
            AnotateActorsOrder(movie);

            context.Add(movie);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private void AnotateActorsOrder(Movie movie)
        { 
            if(movie.MoviesActors is not null)
            {

                for(int i=0; i < movie.MoviesActors.Count; i++)
                {
                    movie.MoviesActors[i].Order = i;
                }
            }
        }


    }
}
