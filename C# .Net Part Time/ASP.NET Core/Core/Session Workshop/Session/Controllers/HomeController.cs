using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Session.Models;

namespace Session.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        return View("Index");
    }

    [HttpPost("process")]
    public IActionResult Process(User newUser)
    {
        if (ModelState.IsValid)
        {
            HttpContext.Session.SetString("username", newUser.UserName);
            HttpContext.Session.SetInt32("Numb", 22);
            return RedirectToAction("Dashboard");
        }
        else
        {
            return View("Index");
        }
    }

    [HttpGet("dashboard")]
    public IActionResult Dashboard()
    {
        string? username = HttpContext.Session.GetString("username");
        return View();
    }

    [HttpPost("update")]
    public IActionResult UpdateNumber(string Value)
    {
        if(Value == "+1")
        {
            int temp = (int)HttpContext.Session.GetInt32("Numb");
            temp += 1;
            HttpContext.Session.SetInt32("Numb", temp);
            return RedirectToAction("Dashboard");
        }
        if(Value == "-1")
        {
            int temp = (int)HttpContext.Session.GetInt32("Numb");
            temp -= 1;
            HttpContext.Session.SetInt32("Numb", temp);
            return RedirectToAction("Dashboard");
        }
        if(Value == "x2")
        {
            int temp = (int)HttpContext.Session.GetInt32("Numb");
            temp *= 2;
            HttpContext.Session.SetInt32("Numb", temp);
            return RedirectToAction("Dashboard");
        }
        if(Value == "random")
        {
            Random rand = new Random();
            int MyRandomNumber = rand.Next(1,11);
            int temp = (int)HttpContext.Session.GetInt32("Numb");
            temp += MyRandomNumber;
            HttpContext.Session.SetInt32("Numb", temp);
            return RedirectToAction("Dashboard");
        }
        else
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }

    [HttpGet("clear")]
    public IActionResult ClearSession()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
