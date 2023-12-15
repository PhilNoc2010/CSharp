#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ExamDay.Models;
public class Coupon
{
    [Key]
    public int CouponID { get; set; }
    [Required(ErrorMessage ="Applicable Site is Required")]
    [Display(Name = "Coupon Site:")]
    public string CouponSite { get; set; }
    [Required(ErrorMessage ="Coupon Code is Required")]
    [Display(Name = "Coupon Code:")]
    public string CouponCode { get; set; }
    [Required(ErrorMessage ="Coupon Description is Required")]
    [MinLength(10,ErrorMessage ="Description is not long enough")]
    [Display(Name = "Discount Description:")]
    public string CouponDesc { get; set; }
    public int UserID { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    public List<ActiveUserCoupon> CouponsUsedBy { get; set; } = new();
    public List<ExpiredUserCoupon> ExpiredCoupons { get; set; } = new();

}