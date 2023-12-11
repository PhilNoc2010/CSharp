using System.ComponentModel.DataAnnotations;
namespace ProdsAndCats.Models;

public class Association
{
    [Key]
    public int AssocationID { get; set; }
    public int  ProductID { get; set; }
    public int  CategoryID { get; set; }
    public DateTime CreatedAt { get; set; }  = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    //Navigation Property ...
    public Product? Product { get; set; }
    public Category? Category { get; set; }

}