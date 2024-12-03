using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FirstConnection.Models;

namespace FirstConnection.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private MyContext _context;  //This is new

    public HomeController(ILogger<HomeController> logger, MyContext context) // injection here
    {
        _logger = logger;
        _context = context; // This is new
    }

    public IActionResult Index()
    {
        return View();
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
