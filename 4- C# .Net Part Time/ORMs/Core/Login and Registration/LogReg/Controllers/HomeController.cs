using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LogReg.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LogReg.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private MyContext _context;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;

    }

    [HttpGet("")]
    public IActionResult Index()
    {
        return View();
    }

    //Post request to create user
    //Hashing password
    //Session 
    [HttpPost("users/create")]
    public IActionResult CreateUser(User newUser)
    {
        if (ModelState.IsValid)
        {
            PasswordHasher<User> Hasher = new PasswordHasher<User>();
            newUser.Password = Hasher.HashPassword(newUser, newUser.Password);
            _context.Add(newUser);
            _context.SaveChanges();
            HttpContext.Session.SetInt32("UserId", newUser.UserId);
            return RedirectToAction("Success");
        }
        else
        {
            return View("Index");
        }
    }

    //Post request to login user
    [HttpPost("users/login")]
    public IActionResult LoginUser(LogUser LoginUser)
    {
        if (ModelState.IsValid)
        {
            User? userInDB = _context.Users.FirstOrDefault(u => u.Email == LoginUser.LogEmail);
            if (userInDB == null)
            {
                ModelState.AddModelError("LogEmail", "Invalid email or password");
                return View("Index");
            }
            PasswordHasher<LogUser> Hasher = new PasswordHasher<LogUser>();
            var result = Hasher.VerifyHashedPassword(LoginUser, userInDB.Password, LoginUser.LogPassword);
            if (result == 0)
            {
                ModelState.AddModelError("LogPassword", "Invalid email or password");
                return View("Index");
            }
            else
            {
                HttpContext.Session.SetInt32("UserId", userInDB.UserId);
                return RedirectToAction("Success");
            }
            // return RedirectToAction("Success");
        }
        else
        {
            return View("Index");
        }
    }

    //Session check
    [SessionCheck]
    [HttpGet("success")]
    public IActionResult Success()
    {
        return View();
    }

    //Clear Session
    [HttpPost("logout")]
    public IActionResult Logout()
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


public class SessionCheckAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        int? userId = context.HttpContext.Session.GetInt32("UserId");
        if (userId == null)
        {
            context.Result = new RedirectToActionResult("Index", "Home", null);
            // context.Result = new RedirectToActionResult("Index", "Home", new { });
        }
    }
}