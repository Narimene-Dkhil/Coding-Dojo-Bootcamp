using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SessionWorkshop.Models;

namespace Session_WorkShop.Controllers;

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

        return View();
    }

    [HttpPost("create")]  
    public IActionResult Create(User newUser)  
    {
        if(ModelState.IsValid)
        {
        HttpContext.Session.SetString("UserName", newUser.Name);
        HttpContext.Session.SetInt32("Digit", 22);
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
            if (HttpContext.Session.GetString("UserName") != null)
                {
                    int? IntVariable = HttpContext.Session.GetInt32("UserAge");
                    return View();
                }
                else{
                    return RedirectToAction("ClearSession");
                }
    }

    [HttpPost("update")]
    public IActionResult UpdateNumber(string Value)
    {
        if(Value == "+1")
        {
            int temp = (int)HttpContext.Session.GetInt32("Digit");
            temp += 1;
            HttpContext.Session.SetInt32("Digit", temp);
            return RedirectToAction("Results");
        }
        if(Value == "-1")
        {
            int temp = (int)HttpContext.Session.GetInt32("Digit");
            temp -= 1;
            HttpContext.Session.SetInt32("Digit", temp);
            return RedirectToAction("Results");
        }
        if(Value == "x2")
        {
            int temp = (int)HttpContext.Session.GetInt32("Digit");
            temp *= 2;
            HttpContext.Session.SetInt32("Digit", temp);
            return RedirectToAction("Results");
        }
        if(Value == "random")
        {
            Random rand = new Random();
            int MyRandomNumber = rand.Next(1,11);
            int temp = (int)HttpContext.Session.GetInt32("Digit");
            temp += MyRandomNumber;
            HttpContext.Session.SetInt32("Digit", temp);
            return RedirectToAction("Results");
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