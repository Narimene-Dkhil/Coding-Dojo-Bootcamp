#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace SessionWorkshop.Models;

public class User
{
    [Required(ErrorMessage = "Name is required!")]
    [MinLength(2, ErrorMessage="Name must be at least 2 chars")]
    public string Name {get;set;}
}