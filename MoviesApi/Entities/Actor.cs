using System;
using System.ComponentModel.DataAnnotations;

namespace MoviesApi.Entities
{
    public class Actor
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public DateTime   DateOfBirth { get; set; }
        public string Biography { get; set; }
        public string Picture { get; set; }
    }
}
