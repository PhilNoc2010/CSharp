using Microsoft.AspNetCore.Mvc;

namespace SurveyController.Controllers;

public class SurveyController : Controller
{
    [HttpGet]
    [Route("")]
    [Route("index")]
    public ViewResult Index()
    {
        return View("Index");
    }

    [HttpGet]
    [Route("results")]
    public ViewResult ShowResults()
    {
        return View("Results");
    }

    [HttpPost]
    [Route("process")]
    public IActionResult Process(string name, string location, string language, string comments)
    {
        ViewBag.name = name;
        ViewBag.location = location;
        ViewBag.language = language;
        ViewBag.comments = comments;

        return View("Results");
    }
}