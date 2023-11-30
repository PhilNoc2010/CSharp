using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ViewModelFun.Models;

namespace ViewModelFun.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }


    public IActionResult Index()
    {
        string myMessage = "Sometimes, some crazy stuff happens";
        int myInteger = 42;
        Console.WriteLine(myMessage);
        return View(myInteger);
    }

    public IActionResult Numbers()
    {
        List<int> myList = new List<int>() {2, 3, 4, 7, 284, 9};
        return View(myList);
    }

    public IActionResult AUser()
    {
        User myUser = new User()
        {
            FirstName = "Douglas",
            LastName = "Addams"
        };
        return View(myUser);
    }

    public IActionResult Users()
    {
        User myUser1 = new User()
        {
            FirstName = "Douglas",
            LastName = "Addams"
        };
        User myUser2 = new User()
        {
            FirstName = "George",
            LastName = "Martin"
        };
        User myUser3 = new User()
        {
            FirstName = "Smarty",
            LastName = "Pants"
        };
        List<User> myUsers = new List<User>();
        myUsers.Add(myUser1);
        myUsers.Add(myUser2);
        myUsers.Add(myUser3);
        return View(myUsers);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
