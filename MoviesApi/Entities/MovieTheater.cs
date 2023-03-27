using NetTopologySuite.Geometries;
using System.ComponentModel.DataAnnotations;

namespace MoviesApi.Entities
{
    public class MovieTheater
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public Point Location { get; set; }


    }
}
