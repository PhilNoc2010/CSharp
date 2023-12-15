using WeddingPlanner.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WeddingPlanner.Controllers;

[SessionCheck]
public class WeddingController : Controller
{
    private readonly ILogger<WeddingController> _logger;
    private readonly MyContext _context ;

    public WeddingController(ILogger<WeddingController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet("weddings")]
    public IActionResult ShowWeddings()
    {
        //code to grab and display weddings will go here
        List<Wedding> WeddingList = _context.Weddings
                                            .Include(wg => wg.WeddingGuestList)
                                            .OrderByDescending(w => w.CreatedAt).ToList();
        return View(WeddingList);
    }

    [HttpGet("weddings/new")]
    public IActionResult AddWedding()
    {
        return View();
    }

    [HttpPost("weddings/create")]
    public IActionResult MakeWedding(Wedding newWedding)
    {
        if(ModelState.IsValid)
        {
            newWedding.UserID = (int)HttpContext.Session.GetInt32("UserID");
            _context.Add(newWedding);
            _context.SaveChanges();
            return RedirectToAction("ShowWeddings","Wedding");
        }
        else
        {
            return View("../Wedding/AddWedding");
        }
    }

    [HttpGet("weddings/{weddingID}")]
    public IActionResult OneWedding(int weddingID)
    {
        //Get the wedding from the database based on incoming parameter
        Wedding? WeddingToShow = _context.Weddings
                                .Include(wgl => wgl.WeddingGuestList)
                                .ThenInclude(wg => wg.WeddingGuest)
                                .FirstOrDefault(w => w.WeddingID == weddingID);
        Console.WriteLine("\n\n\n Got the Wedding Info\n\n\n");

        return View("OneWedding", WeddingToShow);
    }

    [HttpPost("weddings/{weddingID}/delete")]
    public IActionResult DeleteWedding(int weddingID)
    {
        //validate that the wedding exists before attempting to delete
        //this prevents weird errors from occurring
        Wedding? WeddingToDelete = _context.Weddings.FirstOrDefault(w => w.WeddingID == weddingID && w.UserID == (int)HttpContext.Session.GetInt32("UserID"));
        if (WeddingToDelete != null)
        {
            _context.Weddings.Remove(WeddingToDelete);
            _context.SaveChanges();
        }
        return RedirectToAction("ShowWeddings", "Wedding");
    }

    [HttpPost("weddings/{weddingID}/toggleRSVP")]
    public IActionResult ToggleRSVP(int weddingID)
    {
        int userID = (int)HttpContext.Session.GetInt32("UserID");

        //Search the database to determine the current state of the RSVP.
        //If none are found, one will be created and added.
        WeddingPlan? RSVPCheck = _context.WeddingPlans.FirstOrDefault(p => p.WeddingID == weddingID && p.UserID == userID);
        if (RSVPCheck == null)
        {
            WeddingPlan newRSVP = new () {UserID = userID, WeddingID = weddingID} ;
            _context.WeddingPlans.Add(newRSVP);

        }
        else
        {
            _context.WeddingPlans.Remove(RSVPCheck);
        }
        _context.SaveChanges();

        return Redirect(HttpContext.Request.Headers.Referer);
    }
}