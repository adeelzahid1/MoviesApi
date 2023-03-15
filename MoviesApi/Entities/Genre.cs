using MoviesApi.Validation;
using System.ComponentModel.DataAnnotations;

namespace MoviesApi.Entities
{
    public class Genre
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "The {0} Field is Required")]
        [StringLength(50)]
        [FirstLetterCapital]
        public string Name { get; set; }

    }
}
