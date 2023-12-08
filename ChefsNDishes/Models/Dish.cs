#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace ChefsNDishes.Models;
public class Dish
{
    [Key]
    public int DishId { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    [Range(1,5)]
    public int Tastiness { get; set; }
    [Required]
    [GreaterThan0]
    public int Calories { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    //Foreign Key Referring to Chefs table/Model
    public int ChefID {get;set;}
    // Navigation Property to track which chef made this dish
    public Chef? Creator { get; set; }
}

public class GreaterThan0Attribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if((int)value <= 0)
        {
            return new ValidationResult("Calories must be greater than 0");
        }
        else
        {
            return ValidationResult.Success;
        }
    }
}