#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace ProdCat.Models;
public class Product 
{
    [Key]
    public int ProductId { get; set; }
    [Required]
    [MinLength(2, ErrorMessage = "Name must be at least 2 characters")]
    public string Name { get; set; } 
    [Required]
    [MinLength(5, ErrorMessage = "Description must be at least 5 characters")]
    public string Description { get; set; }
    [Required]
    [Range(1, double.MaxValue, ErrorMessage = "Price must be at least $1")]
    public double Price { get; set; } = 1;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    //Navigation property
    public List<Association> MyProducts { get; set; } = new List<Association>();
}