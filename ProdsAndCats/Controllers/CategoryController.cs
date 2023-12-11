using ProdsAndCats.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;

namespace ProdsAndCats.Controllers;

public class CategoryController : Controller
{
    private readonly ILogger<CategoryController> _logger;
    private readonly MyContext _context ;

    public CategoryController(ILogger<CategoryController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpPost("category/create")]
    public IActionResult AddCategory(Category newCategory)
    {
        if(ModelState.IsValid)
        {
            _context.Add(newCategory);
            _context.SaveChanges();
            return RedirectToAction("CategoryPage","Home");
        }
        else
        {
            Console.WriteLine("Failed Validation");
            return View("../Home/Categories");
        }
    }

    [HttpPost("category/{catID}/add/")]
    public IActionResult AddToCategory(Association assocID)
    {
        Console.WriteLine($"\n\n\n ProdID: {assocID.ProductID} Category ID: {assocID.CategoryID} \n\n\n");
        //Validate that the product isn't already associated to the given cateogyr
        Association? newProdAssociationToCat = _context.Associations.FirstOrDefault(pac => pac.CategoryID == assocID.CategoryID && pac.ProductID == assocID.ProductID);
        //Insert the new association if it doesn't already exist
        if (newProdAssociationToCat == null)
        {
            Association newAssociation = new() { ProductID = assocID.ProductID, CategoryID = assocID.CategoryID};
            _context.Add(newAssociation);
            _context.SaveChanges();
        }

        //display the updated category detail page
        return RedirectToAction("GetCategory", "Category");

    }
    [HttpGet("category/show/{catID}")]
    public IActionResult GetCategory(int CatID)
    {
        Category? result = _context.Categories
                                .Include(a => a.AssociatedProducts)
                                .ThenInclude(p => p.Product)
                                .FirstOrDefault(category => category.CategoryID == CatID);
        ViewBag.AllProducts = _context.Products.OrderBy(p => p.ProductID).ToList();
        return View("ShowCategory", result);
    }
}