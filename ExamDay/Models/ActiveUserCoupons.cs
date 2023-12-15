#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ExamDay.Models;

public class ActiveUserCoupon
{
    [Key]
    public int UserCouponID { get; set; }
    public int UserID { get; set; }
    public int CouponID { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    public User? CouponUsedBy { get; set; }
    public Coupon? ActiveCouponInfo { get; set; }
}