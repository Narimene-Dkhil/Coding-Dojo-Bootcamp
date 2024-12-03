using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ChefDish.Models;

namespace ChefDish.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private MyContext _context;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }


    //Display Chefs
    [HttpGet("")]
    public IActionResult Index()
    {
        List<Chef> AllChefs = _context.Chefs.Include(c => c.AllDishes).ToList();
        return View(AllChefs);
    }


    //display Dishes
    [HttpGet("dishes")]
    public IActionResult Dishes()
    {
        List<Dish> AllDishes = _context.Dishes.Include(d => d.Cook).ToList();
        return View(AllDishes);
    }


    //Add Chef get
    [HttpGet("chefs/new")]
    public IActionResult AddChef()
    {
        return View("AddChef");
    }

    //Add chef post
    [HttpPost("chefs/new")]
    public IActionResult CreateChef(Chef newChef)
    {
        if (ModelState.IsValid)
        {
            _context.Add(newChef);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        else
        {
            return View("AddChef");
        }
    }


    //Add Dish get 
    [HttpGet("dishes/new")]
    public IActionResult AddDish()
    {
        ViewBag.AllChefs = _context.Chefs.ToList();
        return View("AddDish");
    }

    //Add Dish post 
    [HttpPost("dishes/new")]
    public IActionResult CreateDish(Dish newDish)
    {
        if (ModelState.IsValid)
        {
            _context.Add(newDish);
            _context.SaveChanges();
            return RedirectToAction("Dishes");
        }
        else
        {
            ViewBag.AllChefs = _context.Chefs.ToList();
            return View("AddDish");
        }
    }



    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
