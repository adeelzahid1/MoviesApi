using MoviesApi.Validation;
using System.ComponentModel.DataAnnotations;

namespace MoviesApi.DTOs
{
    public class GenreCreationDto
    {
        [Required(ErrorMessage = "The {0} Field is Required")]
        [StringLength(50)]
        [FirstLetterCapital]
        public string Name { get; set; }
    }
}
