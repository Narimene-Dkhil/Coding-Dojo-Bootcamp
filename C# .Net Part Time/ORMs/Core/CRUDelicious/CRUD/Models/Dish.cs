#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace CRUD.Models;
public class Dish 
{

    [Key]
    public int DishId { get; set; }
    [Required]
    [MinLength(2, ErrorMessage = "Name must be at least 2 characters")]
    public string Name { get; set; }
    [Required]
    [MinLength(2, ErrorMessage = "Chef must be at least 2 characters")]
    public string Chef { get; set; }
    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Calories must be a positive number.")]
    public int? Calories { get; set; }
    [Required]
    [Range(minimum:1, maximum:5, ErrorMessage = "Tastiness must be between 1 and 5.")]
    public int Tastiness { get; set; }
    [Required]
    [MinLength(10, ErrorMessage = "Description must be at least 10")]
    [MaxLength(1000, ErrorMessage = "Description must be at maximum 1000")]
    public string Description { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

}