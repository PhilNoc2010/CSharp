using LoginReg.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LoginReg.Controllers;

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
            HttpContext.Session.SetString("userName",NewUser.EmailAddr);
            return RedirectToAction("Success","User");
        }
        else
        {
            return View("Index");
        }
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        HttpContext.Session.Clear();
        return View();
    }

    [HttpGet("Success")]
    [SessionCheck]
    public ViewResult Success()
    {
        return View("Success","User");
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
                return View("Index");
            }
            //we have validated that this user exists.  now to check their password
            PasswordHasher<LoginUser> hasher = new PasswordHasher<LoginUser>();
            var result = hasher.VerifyHashedPassword(userLogin, userInDB.Password, userLogin.LoginPassword);
            if (result == 0)
            {
                ModelState.AddModelError("Email", "Invalid Email/Password");
                return View("Index");
            }
            HttpContext.Session.SetInt32("UserID", userInDB.UserID);
            HttpContext.Session.SetString("UserName",userInDB.EmailAddr);
            return View("Success", "User");
        }
        else
        {
            return View("Index");
        }



    }
}
