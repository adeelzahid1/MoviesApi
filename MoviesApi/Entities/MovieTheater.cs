using NetTopologySuite.Geometries;
using System.ComponentModel.DataAnnotations;

namespace MoviesApi.Entities
{
    public class MovieTheater
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public int Name { get; set; }

        public Point Location { get; set; }


    }
}
