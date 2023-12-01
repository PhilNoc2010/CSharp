using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DojoSurveyModel.Models;

namespace DojoSurveyModel.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    [Route("")]
    [Route("index")]
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    [Route("results")]
    public ViewResult ShowResults()
    {
        return View("Results");
    }

    [HttpPost]
    [Route("process")]
    public IActionResult Results(Survey results)
    {
        Console.WriteLine($"Name: {results.Name}");
        Console.WriteLine($"Location: {results.Location}");
        Console.WriteLine($"Language: {results.Language}");
        Console.WriteLine($"Comments: {results.Comments}");
        if(ModelState.IsValid)
        {
            return View(results);
        }
        else
        {
            return View("index");
        }
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
