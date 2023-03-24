using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesApi.DTOs;
using MoviesApi.Entities;
using MoviesApi.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<ActionResult<List<ActorDto>>> GetActors([FromQuery] PaginationDTO paginationDTO)
        {
            var queryable = context.Actors.AsQueryable();
            await HttpContext.InsertParametersPaginationInHeader(queryable);

            var actors = await queryable.OrderBy(x => x.Name).Paginate(paginationDTO).ToListAsync();
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
        public async Task<ActionResult> UpdateActor(int id, [FromForm] ActorCreationDto actorCreationDto)
        {
           
            var actor = await context.Actors.FirstOrDefaultAsync(x => x.Id == id);
            if(actor is null)
            {
                return NotFound();
            }
            actor = mapper.Map(actorCreationDto, actor);
            if (actorCreationDto.Picture is not null)
            {
                actor.Picture = await fileStorageService.EditFile(containerName, actorCreationDto.Picture, actor.Picture);
            }

            await context.SaveChangesAsync();
            return NoContent();
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

            await fileStorageService.DeleteFile(actor.Picture, containerName); 

            return NoContent();
        }


    }
}
