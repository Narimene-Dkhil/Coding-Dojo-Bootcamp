using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ChoreTracker.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
namespace ChoreTracker.Controllers;


public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private MyContext _context;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    //---------------------------- Login Registration Start -----------------------

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
            return RedirectToAction("Dashboard");
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
                return RedirectToAction("Dashboard");
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

    //---------------------------- Login Registration End -----------------------

    //-------------------------------- Dashboard Start ----------------------------------

    // Dashboard View - Now with Search Filter
[SessionCheck]
[HttpGet("dashboard")]
public IActionResult Dashboard(string searchLocation = "")
{
    int? loggedInUserId = HttpContext.Session.GetInt32("UserId");

    if (loggedInUserId == null)
    {
        return RedirectToAction("Index");
    }

    // Retrieve all jobs
    List<Job> allJobs = _context.Jobs.ToList();

    // Filter jobs based on location if a searchLocation is provided
    if (!string.IsNullOrEmpty(searchLocation))
    {
        allJobs = allJobs.Where(job => job.Location.Contains(searchLocation, StringComparison.OrdinalIgnoreCase)).ToList();
    }

    // Get all jobs that have been marked as favorites by any user
    List<int> favoriteJobIds = _context.Favorites
        .Select(f => f.JobId)
        .ToList();

    // Filter out jobs that are in any user's favorites
    List<Job> filteredJobs = allJobs
        .Where(j => !favoriteJobIds.Contains(j.JobId))
        .ToList();

    // Create the view model
    MyViewModel MyModel = new MyViewModel
    {
        AllJobs = filteredJobs,
        User = _context.Users
            .Include(u => u.Favorites)
            .ThenInclude(f => f.Job)
            .FirstOrDefault(u => u.UserId == loggedInUserId) ?? new User()
    };

    ViewBag.LoggedUserId = loggedInUserId;
    ViewBag.SearchLocation = searchLocation;

    return View(MyModel);
}



    // View My Created Jobs
    [SessionCheck]
    [HttpGet("myJobs")]
    public IActionResult MyJobs()
    {
        // Get the logged-in user's ID from the session
        int? userId = HttpContext.Session.GetInt32("UserId");

        if (userId == null)
        {
            return RedirectToAction("Index"); // Redirect to login if the user is not logged in
        }

        // Get all jobs created by the logged-in user
        MyViewModel myJobsModel = new MyViewModel
        {
            AllJobs = _context.Jobs.Where(job => job.UserId == userId).ToList(),
            User = _context.Users.FirstOrDefault(u => u.UserId == userId) ?? new User()
        };

        return View("MyJobs", myJobsModel);
    }



    //Create Job
    //View
    [SessionCheck]
    [HttpGet("addJob")]
    public IActionResult AddJob()
    {
        return View("AddJob");
    }

    // POST
    [HttpPost("addJob")]
    public IActionResult CreateJob(Job newJob)
    {
        if (ModelState.IsValid)
        {
            int userId = (int)HttpContext.Session.GetInt32("UserId");

            newJob.UserId = userId;

            _context.Add(newJob);
            _context.SaveChanges();
            return RedirectToAction("Dashboard", new { jobId = newJob.JobId });
        }
        else
        {
            return View("AddJob");
        }
    }


    //Update Job
    //View
    [SessionCheck]
    [HttpGet("edit/{jobId}")]
    public IActionResult EditJob(int jobId)
    {
        Job? jobToEdit = _context.Jobs.FirstOrDefault(e => e.JobId == jobId);
        if (jobToEdit != null)
        {
            return View(jobToEdit);
        }
        else
        {
            return RedirectToAction("Dashobard");
        }
    }

    // POST
    [HttpPost("update/{jobId}")]
    public IActionResult UpdateJob(int jobId, Job updatedJob)
    {
        int userId = (int)HttpContext.Session.GetInt32("UserId");

        Job? jobToEdit = _context.Jobs.FirstOrDefault(e => e.JobId == jobId);

        if (jobToEdit == null || jobToEdit.UserId != userId)
        {
            return RedirectToAction("Dashboard");
        }

        if (ModelState.IsValid)
        {
            jobToEdit.Title = updatedJob.Title;
            jobToEdit.Description = updatedJob.Description;
            jobToEdit.Location = updatedJob.Location;
            jobToEdit.UpdatedAt = DateTime.Now;

            _context.SaveChanges();

            return RedirectToAction("Dashboard", new { jobId = jobId });
        }

        return View("EditJob", updatedJob);
    }


    //Delete job
    [HttpPost("jobs/{jobId}/delete")]
    public IActionResult DeleteJob(int jobId)
    {
        Job? jobToDelete = _context.Jobs.SingleOrDefault(w => w.JobId == jobId);
        if (jobToDelete != null)
        {
            _context.Jobs.Remove(jobToDelete);
            _context.SaveChanges();
        }
        return RedirectToAction("Dashboard");
    }


    //View One Job
    // Read One 
    [SessionCheck]
    [HttpGet("view/{jobId}")]
    public IActionResult ViewJob(int jobId)
    {
        int? loggedInUserId = HttpContext.Session.GetInt32("UserId");
        if (loggedInUserId == null)
        {
            return RedirectToAction("Index", "Home");
        }

        var job = _context.Jobs
            .Include(p => p.Creator)
            .Include(p => p.Favorites)
            .FirstOrDefault(p => p.JobId == jobId);

        if (job == null)
        {
            return NotFound();
        }

        User? loggedInUser = _context.Users.SingleOrDefault(u => u.UserId == loggedInUserId);

        var viewModel = new MyViewModel
        {
            Job = job,
            User = job.Creator,
            LoggedInUser = loggedInUser
        };

        return View(viewModel);
    }

    //-------------------------------- Dashboard End ----------------------------------


    //---------------------------------Favorites Start --------------------------------

    // Add Job to Favorites
    [HttpPost("addJobToFavorites")]
    public IActionResult AddJobToFavorites(int jobId)
    {
        // Get the logged-in user's ID from the session
        int? userId = HttpContext.Session.GetInt32("UserId");

        if (userId == null)
        {
            return RedirectToAction("Index"); // Redirect to login if the user is not logged in
        }

        // Check if the job is already in favorites
        Favorite existingFavorite = _context.Favorites
            .FirstOrDefault(f => f.UserId == userId && f.JobId == jobId);

        if (existingFavorite == null)
        {
            // Add the job to the user's favorites
            Favorite newFavorite = new Favorite
            {
                UserId = (int)userId,
                JobId = jobId
            };
            _context.Favorites.Add(newFavorite);

            // Save changes to the database
            _context.SaveChanges();
        }

        // Now, return the updated view
        return RedirectToAction("Dashboard");
    }


    // Remove Job from Favorites
    [HttpPost("removeJobFromFavorites")]
    public IActionResult RemoveJobFromFavorites(int jobId)
    {
        // Get the logged-in user's ID from the session
        int? userId = HttpContext.Session.GetInt32("UserId");

        if (userId == null)
        {
            return RedirectToAction("Index"); // Redirect to login if the user is not logged in
        }

        // Find the favorite to remove
        Favorite favoriteToRemove = _context.Favorites
            .FirstOrDefault(f => f.UserId == userId && f.JobId == jobId);

        if (favoriteToRemove != null)
        {
            _context.Favorites.Remove(favoriteToRemove);
            _context.SaveChanges();
        }

        return RedirectToAction("Dashboard");
    }


    //-------------------------------- Favorites End --------------------------------




    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}


//Session Check 
public class SessionCheckAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        int? userId = context.HttpContext.Session.GetInt32("UserId");
        if (userId == null)
        {
            context.Result = new RedirectToActionResult("Index", "Home", null);
        }
    }
}
