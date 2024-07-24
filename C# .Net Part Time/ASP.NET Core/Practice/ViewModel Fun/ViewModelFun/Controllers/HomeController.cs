using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ViewModelFun.Models;

namespace ViewModelFun.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [Route("")]
    public IActionResult Index()
    {
        return View();
    }

    [Route("numbers")]
    public IActionResult Numbers()
    {
        List<int> MyNumbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7 };
        return View(MyNumbers);
    }

    [Route("user")]
    public new IActionResult User()
    {
        User Neil = new User()
        {
            FirstName = "Neil",
            LastName = "Gaiman"
        };
        User Terry = new User()
        {
            FirstName = "Terry",
            LastName = "Pratchet"
        };
        User Jane = new User()
        {
            FirstName = "Jane",
            LastName = "Austen"
        };
        User Stephen = new User()
        {
            FirstName = "Stephen",
            LastName = "King"
        };
        User Mary = new User()
        {
            FirstName = "Mary",
            LastName = "Shelley"
        };
        List<User> UsersList = new List<User>();
        UsersList.Add(Neil);
        UsersList.Add(Terry);
        UsersList.Add(Jane);
        UsersList.Add(Stephen);
        UsersList.Add(Mary);
        return View(UsersList);
    }

    [Route("users")]
    public IActionResult Users()
    {
        User Neil = new User()
        {
            FirstName = "Neil",
            LastName = "Gaiman"
        };
        User Terry = new User()
        {
            FirstName = "Terry",
            LastName = "Pratchet"
        };
        User Jane = new User()
        {
            FirstName = "Jane",
            LastName = "Austen"
        };
        User Stephen = new User()
        {
            FirstName = "Stephen",
            LastName = "King"
        };
        User Mary = new User()
        {
            FirstName = "Mary",
            LastName = "Shelley"
        };
        List<User> UsersList = new List<User>();
        UsersList.Add(Neil);
        UsersList.Add(Terry);
        UsersList.Add(Jane);
        UsersList.Add(Stephen);
        UsersList.Add(Mary);
        return View(UsersList);
    }



    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
