#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BeltExam.Models;
public class User
{
    [Key]
    public int UserId { get; set; }

    [Required(ErrorMessage = "Name is required")]
    [MinLength(2, ErrorMessage = "Name must be at least 2 characters")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Email address is required")]
    [EmailAddress]
    [UniqueEmail]
    public string Email { get; set; }


    [Required(ErrorMessage = "Password is required")]
    [MinLength(8, ErrorMessage = "Password must be at least 8 characters")]
    [DataType(DataType.Password)] 
    public string Password { get; set; }

    //Not mapped Confirm Password
    [NotMapped]
    [Required(ErrorMessage = "Confirm Password is required")]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "Password & Confirm Password not matching!")]
    [Display(Name = "Confirm Password")]
    public string Confirm { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    // One to Many join
    public List<Post> AllPosts { get; set; } = new List<Post>();
    // Many to many join
    public List<Like> Likes { get; set; } = new List<Like>();

}

public class UniqueEmailAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value == null)
        {
            return new ValidationResult("Email is required!");
        }

        MyContext? _context = validationContext.GetService(typeof(MyContext)) as MyContext;
        if (_context == null)
        {
            throw new InvalidOperationException("MyContext is not available.");
        }

        if (_context.Users.Any(e => e.Email == value.ToString()))
        {
            return new ValidationResult("Email must be unique!");
        }
        else
        {
            return ValidationResult.Success;
        }
    }
}

