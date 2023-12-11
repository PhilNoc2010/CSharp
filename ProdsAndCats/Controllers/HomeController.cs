using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProdsAndCats.Models;

namespace ProdsAndCats.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly MyContext _context ;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        List<Product> AllProducts = _context.Products
                                        .OrderByDescending(p => p.Name).ToList();
        Console.WriteLine($"Found {AllProducts.Count} products");
        return View("Index", AllProducts);
    }

    [HttpGet("categories")]
    public IActionResult CategoryPage()
    {
        Console.WriteLine("Loading Category Page");
        List<Category> AllCategories = _context.Categories
                                        .OrderBy(c => c.Name).ToList();
        return View("Categories", AllCategories);
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
