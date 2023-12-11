using System.ComponentModel.DataAnnotations;
namespace ProdsAndCats.Models;

public class Product
{
    [Key]
    public int ProductID { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public float Price { get; set; }
    public DateTime CreatedAt { get; set; }  = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    // Navigation Property to tie a products into appropriate category(s)
    public List<Association> ProductCategories { get; set; } = new List<Association>();

}
