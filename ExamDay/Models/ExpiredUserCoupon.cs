#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ExamDay.Models;

public class ExpiredUserCoupon
{
    [Key]
    public int ExpiredCouponID { get; set; }
    public int UserID { get; set; }
    public int CouponID { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    public User? CouponExpiredBy { get; set; }
    public Coupon? ExpiredCouponInfo { get; set; }
}