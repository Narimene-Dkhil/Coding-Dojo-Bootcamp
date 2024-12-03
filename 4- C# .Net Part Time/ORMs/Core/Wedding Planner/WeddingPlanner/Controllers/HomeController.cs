using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WeddingPlanner.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace WeddingPlanner.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private MyContext _context;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    //----------------------------Login Registration Start -----------------------
    //View REGISTER LOGIN 
    [HttpGet("")]
    public IActionResult Index()
    {
        return View();
    }

    //REGISTER

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
            return RedirectToAction("Weddings");
        }
        else
        {
            return View("Index");
        }
    }

    //LOGIN

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
                return RedirectToAction("Weddings");
            }
        }
        else
        {
            return View("Index");
        }
    }
    //LOGOUT
    [SessionCheck]
    [HttpGet("logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }


    //----------------------------Login Registration End -----------------------

    //----------------------------Dashboard Start -----------------------

    //VIEW ALL
    [SessionCheck]
    [HttpGet("weddings")]
    public IActionResult Weddings()
    {
        MyViewModel MyModel = new MyViewModel
        {
            AllWeddings = _context.Weddings.Include(w => w.Guests).ToList(),
            User = _context.Users.FirstOrDefault(u => u.UserId == HttpContext.Session.GetInt32("UserId")) ?? new User()
        };
        return View(MyModel);
    }


    //DELETE
    [HttpPost("weddings/{weddingId}/delete")]
    public IActionResult DeleteWedding(int weddingId)
    {
        Wedding? weddingToDelete = _context.Weddings.FirstOrDefault(w => w.WeddingId == weddingId);
        if (weddingToDelete != null)
        {
            _context.Weddings.Remove(weddingToDelete);
            _context.SaveChanges();
        }
        return RedirectToAction("Weddings");
    }

    //CREATE
    //VIEW
    [SessionCheck]
    [HttpGet("weddings/new")]
    public IActionResult AddWedding()
    {
        int? Id = HttpContext.Session.GetInt32("UserId");
        ViewBag.LoggedUser = _context.Users.FirstOrDefault(u => u.UserId == Id);
        return View("AddWedding");
    }

    //POST
    [HttpPost("weddings/create")]
    public IActionResult CreateWedding(Wedding newWedding)
    {
        if (ModelState.IsValid)
        {
            newWedding.UserId = (int)HttpContext.Session.GetInt32("UserId");
            _context.Add(newWedding);
            _context.SaveChanges();
            return RedirectToAction("OneWedding", new { Id = newWedding.WeddingId });
        }
        else
        {
            int? Id = HttpContext.Session.GetInt32("UserId");
            ViewBag.LoggedUser = _context.Users.FirstOrDefault(u => u.UserId == Id);
            return View("AddWedding");
        }
    }


    // View One Wedding
    [SessionCheck]
    [HttpGet("weddings/{Id}")]
    public IActionResult OneWedding(int Id)
    {
        int? UId = HttpContext.Session.GetInt32("UserId");
        ViewBag.LoggedUser = _context.Users.FirstOrDefault(u => u.UserId == UId);

        Wedding? OneWedding = _context.Weddings
            .Include(w => w.Guests)
            .ThenInclude(g => g.User)
            .FirstOrDefault(w => w.WeddingId == Id);

        if (OneWedding == null)
        {
            return RedirectToAction("Weddings");
        }

        MyViewModel MyModel = new MyViewModel
        {
            User = _context.Users.FirstOrDefault(u => u.UserId == UId) ?? new User(),
            Wedding = OneWedding,
            AllWeddings = new List<Wedding> { OneWedding }
        };

        return View(MyModel);
    }


    // UPDATE 
    //POST
    [SessionCheck]
    [HttpGet("weddings/{Id}/edit")]
    public IActionResult EditWedding(int Id)
    {
        int? UId = HttpContext.Session.GetInt32("UserId");
        ViewBag.LoggedUser = _context.Users.FirstOrDefault(u => u.UserId == UId);
        Wedding? WeddingToEdit = _context.Weddings.FirstOrDefault(e => e.WeddingId == Id);
        if (WeddingToEdit != null)
        {
            return View(WeddingToEdit);
        }
        else
        {
            return RedirectToAction("Weddings");
        }
    }

    // POST
    [HttpPost("weddings/{Id}/update")]
    public IActionResult UpdateWedding(int Id, Wedding NewVersion)
    {
        Wedding? OldVersion = _context.Weddings.FirstOrDefault(e => e.WeddingId == Id);
        if (ModelState.IsValid)
        {
            OldVersion.Bride = NewVersion.Bride;
            OldVersion.Groom = NewVersion.Groom;
            OldVersion.EventDate = NewVersion.EventDate;
            OldVersion.Address = NewVersion.Address;
            _context.SaveChanges();
            return RedirectToAction("OneWedding", new { id = Id });
        }
        else
        {
            return View("UpdateWedding", OldVersion);
        }
    }


    //----------------------------RSVP---------------------------------

    // Create RSVP Associations 
    [HttpPost("RSVP")]
    public IActionResult RSVP(int UserId, int WeddingId)
    {
        Rsvp newRsvp = new Rsvp
        {
            UserId = UserId,
            WeddingId = WeddingId
        };
        _context.Add(newRsvp);
        _context.SaveChanges();
        return RedirectToAction("Weddings");
    }

    // Remove RSVP Associations
    [HttpPost("RSVP/{Id}/remove")]
    public IActionResult rsvpRemove(int Id)
    {
        Rsvp rsvpToRemove = _context.Rsvps.SingleOrDefault(r => r.RsvpId == Id);
        _context.Rsvps.Remove(rsvpToRemove);
        _context.SaveChanges();
        return RedirectToAction("Weddings");
    }



    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}


//Session check 
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