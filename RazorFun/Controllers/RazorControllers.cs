using Microsoft.AspNetCore.Mvc;

namespace RazorController.Controllers;

public class RazorController : Controller
{
    [HttpGet]
    [Route("")]
    public ViewResult Index()
    {
        return View("Index");
    }
}