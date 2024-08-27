#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WeddingPlanner.Models;
public class Wedding
{
    [Key]
    public int WeddingId { get; set; }

    [Required]
    [MinLength(2, ErrorMessage = "Wedder One must be at least 2 Characters")]
    [Display(Name = "Wedder One")]
    public string Bride { get; set; }

    [Required]
    [MinLength(2, ErrorMessage = "Wedder Two must be at least 2 Characters")]
    [Display(Name = "Wedder Two")]
    public string Groom { get; set; }

    [Required]
    [DataType(DataType.Date)]
    [FutureDate]
    [Display(Name ="Event Date")]
    public DateTime EventDate { get; set; }

    [Required]
    [MinLength(2, ErrorMessage = "Address must be at least 2 Characters")]
    public string Address { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

     // One to many join 
    public int UserId { get; set; }
    public User? Creator { get; set; }
    // Many to many join
    public List<Rsvp> Guests { get; set; } = new List<Rsvp>();

}

public class FutureDateAttribute : ValidationAttribute
{
protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
            DateTime CurrentTime = DateTime.Now;
        if ((DateTime?)value < CurrentTime)
        {
            return new ValidationResult("Date must be in future!");
        } 
        else {
            return ValidationResult.Success;
        }
    }
}
