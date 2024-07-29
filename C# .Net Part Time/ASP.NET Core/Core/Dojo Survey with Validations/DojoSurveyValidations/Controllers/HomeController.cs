using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DojoSurveyValidations.Models;

namespace DojoSurveyValidations.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    static User? user;


    [HttpGet("")]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost("process")]
    public IActionResult Process(User newUser)
    {
        if (ModelState.IsValid)
        {
            user = newUser;
            return RedirectToAction("Results");
        }
        else
        {
            return View("Index");
        }
    }

    [HttpGet("results")]
    public IActionResult Results()
    {
        return View(user);
    }




    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
