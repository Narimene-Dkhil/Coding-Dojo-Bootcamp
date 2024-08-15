#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace ChefDish.Models;
public class Chef 
{
    [Key]
    public int ChefId { get; set; }


    [Required]
    [MinLength(2, ErrorMessage = "First Name must be at least 2 characters")]
    [Display(Name = "First Name")]
    public string FirstName { get; set; }


    [Required]
    [MinLength(2, ErrorMessage = "Last Name must be at least 2 characters")]
    [Display(Name = "Last Name")]
    public string LastName { get; set; }


    [Required]
    [DataType(DataType.Date)]
    [PastDate]
    [Display(Name = "Date of Birth")]
    public DateTime DoB {get; set; }


    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    public List<Dish> AllDishes { get; set; } = new List<Dish>();
}


// public class PastDateAttribute : ValidationAttribute
// {
// protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
// {
//     if (value == null)
//     {
//         return new ValidationResult("A date must be provided.");
//     }

//     DateTime CurrentTime = DateTime.Now;
//     DateTime eighteen = CurrentTime.AddYears(-18);

//     if ((DateTime)value > eighteen)
//     {
//         return new ValidationResult("You must be 18 or older to register!");
//     }

//     return ValidationResult.Success;
// }

// }





public class PastDateAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        // Check if value is null
        if (value == null)
        {
            // Return success if null because [Required] will handle the null check.
            return ValidationResult.Success;
        }

        DateTime minDate = new DateTime(1900, 1, 1);
        DateTime currentDate = DateTime.Now;

        // Ensure the value is a valid DateTime
        if (value is DateTime dateValue)
        {
            if (dateValue < minDate || dateValue > currentDate)
            {
                return new ValidationResult($"Birthday must be between {minDate.ToShortDateString()} and {currentDate.ToShortDateString()}!");
            }

            // Calculate the age
            int age = currentDate.Year - dateValue.Year;
            if (dateValue > currentDate.AddYears(-age))
            {
                age--;
            }

            // Ensure the chef is at least 18 years old
            if (age < 18)
            {
                return new ValidationResult("Chef must be at least 18 years old!");
            }

            return ValidationResult.Success;
        }

        // Return an error if the value is not a valid DateTime
        return new ValidationResult("Invalid date format.");
    }
}








// public class PastDateAttribute : ValidationAttribute
// {
//     protected override ValidationResult? IsValid(object value, ValidationContext validationContext)
//     {
//         DateTime minDate = new DateTime(1900, 1, 1);
//         DateTime currentDate = DateTime.Now;

//         DateTime dateValue = (DateTime)value;

//         if (dateValue < minDate || dateValue > currentDate)
//         {
//             return new ValidationResult($"Birthday must be between {minDate.ToShortDateString()} and {currentDate.ToShortDateString()}!");
//         }

//         // Calculate the age
//         int age = currentDate.Year - dateValue.Year;
//         if (dateValue > currentDate.AddYears(-age))
//         {
//             age--;
//         }

//         // Ensure the chef is at least 18 years old
//         if (age < 18)
//         {
//             return new ValidationResult("Chef must be at least 18 years old!");
//         }

//         return ValidationResult.Success;
//     }
// }




// public class PastDateAttribute : ValidationAttribute
// {
//     protected override ValidationResult? IsValid(object value, ValidationContext validationContext)
//     {
//         DateTime minDate = new DateTime(1900, 1, 1);
//         DateTime currentDate = DateTime.Now;

//         DateTime dateValue = (DateTime)value;

//         if (dateValue < minDate || dateValue > currentDate)
//         {
//             return new ValidationResult($"Birthday must be between {minDate.ToShortDateString()} and {currentDate.ToShortDateString()}!");
//         }

//         return ValidationResult.Success;
//     }
// }