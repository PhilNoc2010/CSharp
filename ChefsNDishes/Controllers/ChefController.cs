using ChefsNDishes.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ChefsNDishes.Controllers;
public class ChefController : Controller
{
    private MyContext _context;

    public ChefController(MyContext context)
    {
        _context = context;
    }

    public ViewResult NewChef()
    {
        return View();
    }

    //Create
    [HttpPost]
    public IActionResult AddChef(Chef newChef)
    {
        Console.WriteLine("Adding Chef");
        if (ModelState.IsValid)
        {
            Console.WriteLine("Passed Validation");
            _context.Add(newChef);
            _context.SaveChanges();
        }
        else
        {
            Console.WriteLine("Failed Validation");
            return View("NewChef");
        }
        return RedirectToAction("Index","Home");
    }

}