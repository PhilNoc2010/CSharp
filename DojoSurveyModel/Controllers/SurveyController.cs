using DojoSurveyModel.Models;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;

namespace DojoSurveyModel.Controllers;

public class SurveyController : Controller
{
    // [HttpGet]
    // [Route("")]
    // [Route("index")]
    // public ViewResult Index()
    // {
    //     return View("Index");
    // }

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
        return View(results);
    }
}