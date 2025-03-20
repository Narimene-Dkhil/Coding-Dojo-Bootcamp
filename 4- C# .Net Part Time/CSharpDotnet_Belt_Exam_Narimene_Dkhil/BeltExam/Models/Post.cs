#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace BeltExam.Models;
public class Post
{
    [Key]
    public int PostId { get; set; }

    [Required]
    [MinLength(3, ErrorMessage = "Image URL must be at least 3 characters")]
    [Display(Name = "Image (URL format please)")]
    public string Image { get; set; }

    [Required]
    [MinLength(2, ErrorMessage = "Title must be at least 2 characters")]
    public string Title { get; set; }

    [Required]
    [MinLength(2, ErrorMessage = "Medium must be at least 2 characters")]
    public string Medium { get; set; }

    [Required]
    [Display(Name = "For Sale?")]
    public bool ForSale { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    // One to many join 
    public int UserId { get; set; }
    public User? Creator { get; set; }
    // Many to many join
    public List<Like> Likers { get; set; } = new List<Like>();
}