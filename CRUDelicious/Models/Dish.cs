#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Net.Http.Headers;

namespace CRUDelicious.Models;

public class Dish
{
    public int DishID {get;set;}
    [Required(ErrorMessage ="Dish Name is required")]
    [MinLength(3, ErrorMessage ="Dish Name must be longer than 3 characters")]
    public string Name {get;set;}
    [Required(ErrorMessage ="Chef's Name is required")]
    [MinLength(3,ErrorMessage ="Chef's Name must be longer than 3 characters")]
    public string Chef {get;set;}
    public int Tastiness {get;set;}
    [Required(ErrorMessage ="A number of calories must be provided")]
    [Range(10,1000,ErrorMessage ="Calories must be between 10 and 1000")]
    public int Calories {get;set;}
    [Required(ErrorMessage ="Description is required")]
    [MinLength(5,ErrorMessage ="Description must be longer than 5 characters")]
    [MaxLength(200,ErrorMessage ="Description cannot exceed 200 characters")]
    public string Description {get;set;}
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}