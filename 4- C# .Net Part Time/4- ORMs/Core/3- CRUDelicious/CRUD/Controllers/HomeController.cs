using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CRUD.Models;

namespace CRUD.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private MyContext _context;  

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context; 
    }
    //READ ALL 
    [HttpGet("")]
    public IActionResult Index()
    {
        List<Dish> AllDishes = _context.Dishes.OrderByDescending(d => d.CreatedAt).ToList();
        return View(AllDishes);
    }

    //CREATE
    [HttpGet("dishes/new")]
    public IActionResult CreateDish()
    {
        return View("CreateDish");
    }
    [HttpPost("dishes/new")]
public IActionResult AddDish(Dish newDish)
    {
        if (ModelState.IsValid)
        {
            _context.Dishes.Add(newDish);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View("CreateDish");
    }


    //READ ONE
    [HttpGet("dishes/{dishId}")]
    public IActionResult Details(int dishId)
    {
        Dish? dish = _context.Dishes.FirstOrDefault(d => d.DishId == dishId);
        // if (dish == null)
        // {
        //     return NotFound();
        // }
        return View("Details", dish);
    }

    //DELETE 
    [HttpPost("dishes/{dishId}/delete")]
    public IActionResult DeleteDish(int dishId)
    {
        Dish? dishToDelete = _context.Dishes.SingleOrDefault(d => d.DishId == dishId);
        if (dishToDelete!= null)
        {
            _context.Dishes.Remove(dishToDelete);
            _context.SaveChanges();
        }
        return RedirectToAction("Index");
    }

    //UPDATE
    //GET
    [HttpGet("dishes/{dishId}/edit")]
    public IActionResult EditDish(int dishId)
    {
        Dish? dishToEdit = _context.Dishes.FirstOrDefault(d => d.DishId == dishId);
        return View("EditDish", dishToEdit);
    }

    //POST
    [HttpPost("dishes/{dishId}/edit")]
    public IActionResult UpdateDish(int dishId, Dish updatedDish)
    {
        Dish? dishToEdit = _context.Dishes.FirstOrDefault(d => d.DishId == dishId);
        if (dishToEdit == null)
        {
            return RedirectToAction ("Index");
        }

        if (ModelState.IsValid)
        {
            dishToEdit.Name = updatedDish.Name;
            dishToEdit.Chef = updatedDish.Chef;
            dishToEdit.Calories = updatedDish.Calories;
            dishToEdit.Tastiness = updatedDish.Tastiness;
            dishToEdit.Description = updatedDish.Description;
            dishToEdit.UpdatedAt = DateTime.Now;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        else
        {
            return View("EditDish", dishToEdit);
        }
    }



    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
