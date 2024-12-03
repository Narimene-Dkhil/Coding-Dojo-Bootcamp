#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace LogReg.Models;
public class LogUser
{

    [EmailAddress]
    [Display(Name = "Email")]
    public string LogEmail { get; set; }
    
    [Required]
    [MinLength(8, ErrorMessage = "Password must be at least 8 Characters")]
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string LogPassword { get; set; }
}

