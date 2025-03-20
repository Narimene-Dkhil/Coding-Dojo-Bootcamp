#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace BeltExam.Models;

public class Like
{
    [Key]
    public int LikeId { get; set; }

    [Required]
    public int UserId { get; set; }
    [Required]
    public int PostId { get; set; }

    public User? User { get; set; }
    public Post? Post { get; set; }
}