#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace DebuggingChallenge.Models;

public class User
{
    [Required(ErrorMessage = "Name is required!")]   
    // We can stack annotations to apply multiple requirements to one property
    // In this case, a Name is required but must also be at least 2 characters long 
    [MinLength(2, ErrorMessage="Must be at least 2 chars")]  
    public string Name {get;set;}

    public string? Location {get;set;}
}