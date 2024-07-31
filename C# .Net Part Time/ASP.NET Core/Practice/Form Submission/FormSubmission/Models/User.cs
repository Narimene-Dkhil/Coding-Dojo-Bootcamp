#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace FormSubmission.Models;

public class User
{
    [Required]
    [MinLength(2, ErrorMessage = "Name must be at least 2 chars!")]
    public string Name { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Date)]
    [PastDate]
    public DateTime Birthday { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [MinLength(8, ErrorMessage = "Password must be at least 2 chars!")]
    public string Password { get; set; }

    [Required]
    [OddNumber]
    public int OddNumber { get; set; }
}

public class PastDateAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object value, ValidationContext validationContext)
    {
        DateTime minDate = new DateTime(1900, 1, 1);
        DateTime currentDate = DateTime.Now;

        DateTime dateValue = (DateTime)value;

        if (dateValue < minDate || dateValue > currentDate)
        {
            return new ValidationResult($"Birthday must be between {minDate.ToShortDateString()} and {currentDate.ToShortDateString()}!");
        }

        return ValidationResult.Success;
    }
}

public class OddNumberAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if ((int)value % 2 == 0)
        {
            return new ValidationResult("Number must be odd!");
        }
        else
        {
            return ValidationResult.Success;
        }
    }
}