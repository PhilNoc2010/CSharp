using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SessionWorkshop.Models;

namespace SessionWorkshop.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [HttpPost]
    [Route("Login")]
    public IActionResult Login(string name)
    {
        HttpContext.Session.SetString("UserName",name);
        HttpContext.Session.SetInt32("PageValue",0);
        return RedirectToAction("Dashboard");
    }

    public IActionResult Dashboard()
    {
        if (HttpContext.Session.GetString("UserName") == null)
        {
            return RedirectToAction("Index");
        }
        return View("Dashboard");
    }

    [Route("Logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }

    public IActionResult ManipulateValue(int value, string operation)
    {
        Console.WriteLine("Got to Manipulate Action");
        if (operation == "random")
        {
            Random rand = new Random();
            HttpContext.Session.SetInt32("PageValue",value+rand.Next(1,11));
        }
        if (operation == "add1")
        {
            HttpContext.Session.SetInt32("PageValue",value+1);
        }
        if (operation == "sub1")
        {
            HttpContext.Session.SetInt32("PageValue",value-1);
        }
        if (operation == "multiply")
        {
            HttpContext.Session.SetInt32("PageValue",value*2);
        }
        return Redirect("Dashboard");
    }

    public IActionResult Add1()
    {
        int value = HttpContext.Session.GetInt32("PageValue") ?? default(int);
        HttpContext.Session.SetInt32("PageValue",value+1);
        return Redirect("Dashboard");
    }
    public IActionResult AddRandom()
    {
        Random rand = new Random();
        int value = HttpContext.Session.GetInt32("PageValue") ?? default(int);
        HttpContext.Session.SetInt32("PageValue",value+rand.Next(1,11));
        return Redirect("Dashboard");
    }
    public IActionResult Sub1()
    {
        int value = HttpContext.Session.GetInt32("PageValue") ?? default(int);
        HttpContext.Session.SetInt32("PageValue",value-1);
        return Redirect("Dashboard");
    }
    public IActionResult Multiply()
    {
        int value = HttpContext.Session.GetInt32("PageValue") ?? default(int);
        HttpContext.Session.SetInt32("PageValue",value*2);
        return Redirect("Dashboard");
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
