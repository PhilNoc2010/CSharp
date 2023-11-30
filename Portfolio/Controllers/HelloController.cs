using Microsoft.AspNetCore.Mvc;

namespace HelloController.Controllers;

public class HelloController : Controller
{
    [HttpGet]
    [Route("")]
    public ViewResult Index()
    {
        return View("Index");
    }

    [HttpGet]
    [Route("projects")]
    public ViewResult Projects()
    {
        return View("Projects");
    }

    [HttpGet]
    [Route("contact")]
    public ViewResult Contact()
    {
        return View("Contact");
    }
}