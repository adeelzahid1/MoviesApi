using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesApi.DTOs;
using MoviesApi.Entities;
using MoviesApi.Helpers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoviesApi.Controllers
{
    [Route("api/actors")]
    [ApiController]
    public class ActorsController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        private readonly IFileStorageService fileStorageService;
        private readonly string containerName = "actors";

        public ActorsController(ApplicationDbContext context, IMapper mapper, IFileStorageService fileStorageService)
        {
            this.context = context;
            this.mapper = mapper;
            this.fileStorageService = fileStorageService;
        }

        [HttpGet]
        [Route("GetActors")]
        public async Task<ActionResult<List<ActorDto>>> GetActors()
        {
            var actors = await context.Actors.ToListAsync();
            return mapper.Map<List<ActorDto>>(actors);
        }

        [HttpGet]
        [Route("GetActor/{id:int}")]
        public async Task<ActionResult<ActorDto>> GetActor(int id)
        {
            var actor = await context.Actors.FirstOrDefaultAsync(x => x.Id == id);
            if (actor is null)
                return NotFound();

            return mapper.Map<ActorDto>(actor);
        }

        [HttpPost]
        [Route("SaveActor")]
        public async Task<ActionResult> SaveActor([FromForm] ActorCreationDto actorCreationDto)
        {
            var actor = mapper.Map<Actor>(actorCreationDto);
            if(actorCreationDto.Picture is not null)
            {
                actor.Picture = await fileStorageService.SaveFile(containerName, actorCreationDto.Picture);

            }
            context.Add(actor);
            await context.SaveChangesAsync();


            return NoContent();
        }
        

        [HttpPut]
        [Route("UpdateActor/{id:int}")]
        public async Task<ActionResult> UpdateActor(int id, [FromBody] ActorCreationDto actorCreationDto)
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        [Route("DeleteActor/{id:int}")]
        public async Task<ActionResult> DeleteActor(int id)
        {
            var actor = await context.Actors.FirstOrDefaultAsync(x => x.Id == id);
            if (actor is null)
                return NotFound();

            context.Remove(actor);
            await context.SaveChangesAsync();

            return NoContent();
        }


    }
}
