#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace Session.Models;

public class User 
{   
    [Required]
    public string UserName { get; set; }
}