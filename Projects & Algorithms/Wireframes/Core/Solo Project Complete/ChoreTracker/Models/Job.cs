#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace ChoreTracker.Models;
public class Job
{
    [Key]
    public int JobId { get; set; }

    [Required]
    [MinLength(2, ErrorMessage = "Title must be at least 2 characters")]
    public string Title { get; set; }
    
    [Required]
    [MinLength(2, ErrorMessage = "Description must be at least 2 characters")]
    public string Description { get; set; }

    [Required]
    [MinLength(2, ErrorMessage = "Location must be at least 2 characters")]
    public string Location { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    // One to many join 
    public int UserId { get; set; }
    public User? Creator { get; set; }
    // Many to many join
    public List<Favorite> Favorites { get; set; } = new List<Favorite>();
}