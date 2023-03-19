using System.ComponentModel.DataAnnotations;
using System;

namespace MoviesApi.DTOs
{
    public class ActorCreationDto
    {

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Biography { get; set; }
        //public string Picture { get; set; }
    }
}
