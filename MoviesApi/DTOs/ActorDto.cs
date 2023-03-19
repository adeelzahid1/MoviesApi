using System.ComponentModel.DataAnnotations;
using System;

namespace MoviesApi.DTOs
{
    public class ActorDto
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Biography { get; set; }
        public string Picture { get; set; }
    }
}
