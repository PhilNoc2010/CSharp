#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace ChefsNDishes.Models;
public class Chef
{
    [Key]
    public int ChefId { get; set; }
    [Required]
    [MinLength(3, ErrorMessage ="First Name must be longer than 3 characters")]
    public string FirstName { get; set; }
    [Required]
    [MinLength(3, ErrorMessage ="Last Name must be longer than 3 characters")]
    public string LastName { get; set; }
    [Required]
    [ChefIsOver18]
    public DateTime DateOfBirth { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    // Navigation property to track all dishes made by our chefs
    public List<Dish> AllDishes { get; set; } = new List<Dish>();
}

public class ChefIsOver18Attribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (DateTime.Compare((DateTime)value, DateTime.Today.AddYears(-18)) > 0)
        {
            Console.WriteLine("Chef is younger than Today");
            return new ValidationResult("Chef Must be Age 18 or older to be added to the Database");
        }
        else
        {
            return ValidationResult.Success;
        }
    }
}