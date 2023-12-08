using ChefsNDishes.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChefsNDishes.Controllers;

public class DishController : Controller
{
    private MyContext _context;
    public DishController (MyContext context)
    {
        _context = context;
    }

    [HttpGet("dish/add")]
    public ViewResult NewDish()
    {
        ViewBag.AllChefs =  _context.Chefs.OrderBy(c => c.ChefId).ToList();
        return View();
    }

    //Create
    [HttpPost]
    public IActionResult AddDish(Dish newDish)
    {
        Console.WriteLine("Adding Dish");
        if (ModelState.IsValid)
        {
            _context.Add(newDish);
            _context.SaveChanges();
        }
        else
        {
            return View("NewDish");
        }
        return RedirectToAction("Dishes","Home");
    }

}
