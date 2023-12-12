#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WeddingPlanner.Models;

public class WeddingPlan
{
    public int WeddingPlanID { get; set; }
    public int UserID { get; set; }
    public int WeddingID { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    public User? WeddingGuest { get; set; }
    public Wedding? WeddingInfo { get; set; }
}