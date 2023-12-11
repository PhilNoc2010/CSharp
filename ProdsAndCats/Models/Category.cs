using System.ComponentModel.DataAnnotations;
namespace ProdsAndCats.Models;

public class Category
{
    [Key]
    public int CategoryID { get; set; }
    [Required]
    [MinLength(2)]
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; }  = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    //Navigation Property ...uses a Many to Many relationship to tie Product and Category tables together
    public List<Association> AssociatedProducts { get; set; } = new List<Association>();

}