#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Net.Http.Headers;

namespace WeddingPlanner.Models;

public class Wedding
{
    [Key]
    public int WeddingID { get; set; }
    [Required]
    [Display(Name = "Wedder #1")]
    public string WedderOne { get; set; }
    [Required]
    [Display(Name = "Wedder #2")]
    public string WedderTwo { get; set; }
    [Required]
    [Display(Name = "Wedding Date")]
    public DateTime WeddingDate { get; set; }
    [Required]
    [Display(Name = "Wedding Location")]
    public string WeddingAddress { get; set ; }
    public int UserID { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    public List<WeddingPlan> WeddingGuestList { get; set; } = new();

}