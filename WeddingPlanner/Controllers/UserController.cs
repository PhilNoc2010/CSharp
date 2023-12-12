using WeddingPlanner.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WeddingPlanner.Controllers;

public class UserController : Controller
{
    private readonly ILogger<UserController> _logger;
    private readonly MyContext _context ;

    public UserController(ILogger<UserController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpPost("users/create")]
    public IActionResult Register(User NewUser)
    {
        if(ModelState.IsValid)
        {
            PasswordHasher<User> Hasher = new PasswordHasher<User>();
            NewUser.Password = Hasher.HashPassword(NewUser,NewUser.Password);
            _context.Add(NewUser);
            _context.SaveChanges();
            HttpContext.Session.SetInt32("UserID", NewUser.UserID);
            HttpContext.Session.SetString("UserName",NewUser.EmailAddr);
            // return View("../Wedding/Weddings");
            return RedirectToAction("ShowWeddings","Wedding");
        }
        else
        {
            return View("../Home/Index");
        }
    }

    [HttpPost("users/login")]
    public IActionResult Login(LoginUser userLogin)
    {
        if(ModelState.IsValid)
        {
            User? userInDB = _context.Users.FirstOrDefault(u => u.EmailAddr == userLogin.LoginEmail);
            if (userInDB == null)
            {
                ModelState.AddModelError("Email", "Invalid Email/Password");
                return View("../Home/Index");
            }
            //we have validated that this user exists.  now to check their password
            PasswordHasher<LoginUser> hasher = new PasswordHasher<LoginUser>();
            var result = hasher.VerifyHashedPassword(userLogin, userInDB.Password, userLogin.LoginPassword);
            if (result == 0)
            {
                ModelState.AddModelError("Email", "Invalid Email/Password");
                return View("../Home/Index");
            }
            HttpContext.Session.SetInt32("UserID", userInDB.UserID);
            HttpContext.Session.SetString("UserName",userInDB.EmailAddr);
            return RedirectToAction("ShowWeddings", "Wedding");
        }
        else
        {
            return View("../Home/Index");
        }
    }

    // [HttpPost("logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index", "Home");
    }
}
