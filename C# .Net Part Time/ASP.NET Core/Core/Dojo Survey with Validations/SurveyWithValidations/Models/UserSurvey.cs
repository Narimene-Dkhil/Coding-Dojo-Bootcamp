#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace SurveyWithValidations.Models;

public class UserSurvey
{
    [Required(ErrorMessage = "REQUIRED!")]
    [MinLength(3, ErrorMessage = "Must be at least 3 characters!")]
    public string Name {get; set;}

    [Required(ErrorMessage = "REQUIRED!")]
    [MinLength(2, ErrorMessage = "Must be at least 2 characters!")]
    public string Language {get; set;}

    [Required(ErrorMessage = "REQUIRED!")]
    [MinLength(3, ErrorMessage = "Must be at least 3 characters!")]
    public string Location {get; set;}

    [StringLength(255, MinimumLength=20 , ErrorMessage = "Must left blank, or min 20 characters!")] // THIS PLUS "?" after string
    public string? Comments {get; set;} // "?" allows a null to be accepted!
}