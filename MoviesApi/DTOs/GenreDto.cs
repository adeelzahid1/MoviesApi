using MoviesApi.Validation;
using System.ComponentModel.DataAnnotations;

namespace MoviesApi.DTOs
{
    public class GenreDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
