using System.ComponentModel.DataAnnotations;

namespace NewVidly2.Core.Models
{
    public class DateAddedGreaterThanDateReleased : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var movie = (Movie)validationContext.ObjectInstance;

            var dateReleased = movie.ReleasedDate;
            var dateAdded = movie.DateAdded;

            if (dateAdded != null && dateReleased != null)
            {
                return (dateAdded.Year > dateReleased.Value.Year)
                    ? ValidationResult.Success
                    : new ValidationResult("Date Added Must Be Greater Than Date Released");
            }

            return new ValidationResult("Date Released or Date Added is null");
        }
    }
}