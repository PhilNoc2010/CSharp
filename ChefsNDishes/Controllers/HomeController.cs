using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ChefsNDishes.Models;
using Microsoft.EntityFrameworkCore;

namespace ChefsNDishes.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private MyContext _context;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet]
    public IActionResult Index()
    {
        List<Chef> AllChefs = _context.Chefs.Include(d => d.AllDishes)
                                    .OrderByDescending(c => c.DateOfBirth).ToList();
        return View("Index",AllChefs);
    }

    [HttpGet]
    public IActionResult Dishes()
    {
        List<Dish> AllDishes = _context.Dishes.Include(c => c.Creator)
                                    .OrderByDescending(d =>d.CreatedAt).ToList();
        return View("Dishes",AllDishes);
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
