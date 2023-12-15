using ExamDay.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExamDay.Controllers;

[SessionCheck]
public class CouponController : Controller
{
    private readonly ILogger<CouponController> _logger;
    private readonly MyContext _context ;

    public CouponController(ILogger<CouponController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet("coupons")]
    public IActionResult ShowCoupons()
    {
        //code to grab and display coupons will go here
        List<Coupon> CouponList = _context.Coupons
                                            .Include(ac => ac.CouponsUsedBy)
                                            .Include(ec => ec.ExpiredCoupons)
                                            .OrderByDescending(c => c.CreatedAt).ToList();
        return View(CouponList);
    }
    [HttpGet("coupons/new")]
    public IActionResult AddCoupon()
    {
        return View();
    }
    [HttpPost("coupons/create")]
    public IActionResult NewCoupon(Coupon newCoupon)
    {
        if(ModelState.IsValid)
        {
            newCoupon.UserID = (int)HttpContext.Session.GetInt32("UserID");
            _context.Add(newCoupon);
            _context.SaveChanges();
            return RedirectToAction("ShowCoupons","Coupon");
        }
        else
        {
            return View("AddCoupon");
        }
    }
    // [HttpPost("coupons/{couponID}/use")]
    public IActionResult UseCoupon(int couponID)
    {
        int UserID = (int)HttpContext.Session.GetInt32("UserID");
        //search the database to validate if the user has used this coupon already
        ActiveUserCoupon? couponCheck = _context.ActiveUserCoupons.FirstOrDefault(c => c.UserID == UserID && c.CouponID == couponID);
        if (couponCheck == null)
        {
            ActiveUserCoupon newCouponUsed = new () {UserID = UserID, CouponID = couponID};
            _context.ActiveUserCoupons.Add(newCouponUsed);
            _context.SaveChanges();
        }


        return Redirect(HttpContext.Request.Headers.Referer);
    }

    // [HttpPost("coupons/{couponID}/use")]
    public IActionResult MarkExpired(int couponID)
    {
        int UserID = (int)HttpContext.Session.GetInt32("UserID");
        //search the database to validate if the user has used this coupon already
        ExpiredUserCoupon? couponCheck = _context.ExpiredUserCoupons.FirstOrDefault(c => c.UserID == UserID && c.CouponID == couponID);
        if (couponCheck == null)
        {
            ExpiredUserCoupon newCouponUsed = new () {UserID = UserID, CouponID = couponID};
            _context.ExpiredUserCoupons.Add(newCouponUsed);
            _context.SaveChanges();
        }


        return Redirect(HttpContext.Request.Headers.Referer);
    }

}