using MoviesApi.Entities;
using System.ComponentModel.DataAnnotations;
using static MoviesApi.CommonServices.CommonServices;

namespace MoviesApi.Validation
{
    public class FirstLetterCapital: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //var genre = (Genre)validationContext.ObjectInstance;
            
            //if ( value is null || string.IsNullOrEmpty(value.ToString() ))


            if ( value is null || value.ToString().IsNullOrEmpty() )
            {
                return ValidationResult.Success;
            }

            var firstLetter = value.ToString()[0].ToString();
            if(firstLetter != firstLetter.ToUpper())
            {
                return new ValidationResult("First Letter Should be upper case");
            }
            return ValidationResult.Success;

            //return base.IsValid(value, validationContext);
        }
    }
}

