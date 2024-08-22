#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace ProdCat.Models;
public class Category 
{
    [Key]
    public int CategoryId { get; set; }
    [Required]
    [MinLength(2, ErrorMessage = "Name must be at least 2 characters")]
    public string Name { get; set; } 
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    //Navigation property 
    public List<Association> MyCategories { get; set; } = new List<Association>();
}