#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace ChefDish.Models;
public class Dish 
{
    [Key]
    public int DishId {get; set;}

    [Required]
    [MinLength(2, ErrorMessage = "Name of dish must be at least 2 characters")]
    [Display(Name ="Name of Dish")]
    public string Name {get; set;}

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Calories must be a positive number.")]
    public int Calories {get; set;}

    [Required]
    [Range(minimum:1, maximum:5, ErrorMessage = "Tastiness must be between 1 and 5.")]
    public int Tastiness {get; set;}

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    public int ChefId { get; set; }
    public Chef? Cook { get; set; }
}