using System.Diagnostics;
using System.Globalization;
using CRUDelicious.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace CRUDelicious.Controllers;

public class DishController : Controller
{
    private readonly ILogger<DishController> _logger;
    private MyContext _context;

    public DishController(ILogger<DishController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }
    [HttpGet("dish/new")]
    public ViewResult NewDish()
    {
        return View();
    }

    //Create
    [HttpPost]
    public IActionResult AddDish(Dish newDish)
    {
        if(ModelState.IsValid)
        {
            _context.Add(newDish);
            _context.SaveChanges();
        }
        return RedirectToAction("Index","Home");
    }
    //Read
    [HttpGet("allDishes")]
    public ViewResult AllDishes()
    {
        List<Dish> AllDishes = _context.Dishes.OrderByDescending(d => d.CreatedAt).ToList();
        return View("Index","Home");
    }
    [HttpGet("GetDish/{dishID}")]
    public IActionResult GetDish(int dishID)
    {
        Dish? result = _context.Dishes.FirstOrDefault(d => d.DishID == dishID);
        return View("ShowDish",result);
    }
    //Update

    [HttpPost("dish/{dishID}/edit")]
    public IActionResult ShowEditDish(int dishID)
    {
        Dish? result = _context.Dishes.FirstOrDefault(d => d.DishID == dishID);
        return View("EditDish",result);
    }

    [HttpPost("dish/{dishID}/update")]
    public IActionResult UpdateDish(Dish NewDish, int dishID)
    {
        Dish? OldDish = _context.Dishes.FirstOrDefault(d => d.DishID == dishID);
        if (ModelState.IsValid)
        {
            OldDish.Name = NewDish.Name;
            OldDish.Chef = NewDish.Chef;
            OldDish.Calories = NewDish.Calories;
            OldDish.Tastiness = NewDish.Tastiness;
            OldDish.Description = NewDish.Description;
            OldDish.UpdatedAt = DateTime.Now;
            _context.SaveChanges();
            return RedirectToAction("Index","Home");
        }
        else
        {
            return View("EditDish", OldDish);
        }
    }

    //Delete
    [HttpPost("dishes/{dishID}/delete")]
    public IActionResult DeleteDish(int dishID)
    {
        Dish? DishToDelete = _context.Dishes.SingleOrDefault(i => i.DishID == dishID);
        _context.Dishes.Remove(DishToDelete);
        _context.SaveChanges();
        return RedirectToAction("Index","Home");
    }
}