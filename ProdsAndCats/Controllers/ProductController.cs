using ProdsAndCats.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;

namespace ProdsAndCats.Controllers;

public class ProductController : Controller
{
    private readonly ILogger<ProductController> _logger;
    private readonly MyContext _context ;

    public ProductController(ILogger<ProductController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpPost("product/create")]
    public IActionResult AddProduct(Product newProduct)
    {
        if(ModelState.IsValid)
        {
            _context.Add(newProduct);
            _context.SaveChanges();
            return RedirectToAction("Index","Home");
        }
        else
        {
            return View("../Home/Index");
        }
    }

    [HttpGet("product/show/{productID}")]
    public IActionResult GetProduct(int ProductID)
    {
        Product? result = _context.Products
                                .Include(p => p.ProductCategories)
                                .ThenInclude(c => c.Category)
                                .FirstOrDefault(prod => prod.ProductID == ProductID);
        return View("ShowProduct", result);
    }



}
