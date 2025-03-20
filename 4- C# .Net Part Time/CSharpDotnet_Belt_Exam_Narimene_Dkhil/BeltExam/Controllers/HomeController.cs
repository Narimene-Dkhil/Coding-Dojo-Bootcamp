using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BeltExam.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
namespace BeltExam.Controllers;

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
            return RedirectToAction("Posts");
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
                return RedirectToAction("Posts");
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

    // All Posts View
    //Read All
    [SessionCheck]
    [HttpGet("posts")]
    public IActionResult Posts()
    {
        int? loggedInUserId = HttpContext.Session.GetInt32("UserId");
        if (loggedInUserId == null)
        {
            return RedirectToAction("Index", "Home");
        }

        var allPosts = _context.Posts
                                .Include(p => p.Creator)
                                .Include(p => p.Likers)
                                .OrderByDescending(c => c.CreatedAt)
                                .ToList();

        User? loggedInUser = _context.Users.SingleOrDefault(u => u.UserId == loggedInUserId);

        var viewModel = new MyViewModel
        {
            AllPosts = allPosts,
            LoggedInUser = loggedInUser
        };

        return View(viewModel);
    }



    // One Post View 
    // Read One 
    [SessionCheck]
    [HttpGet("posts/{postId}")]
    public IActionResult OnePost(int postId)
    {
        int? loggedInUserId = HttpContext.Session.GetInt32("UserId");
        if (loggedInUserId == null)
        {
            return RedirectToAction("Index", "Home");
        }

        var post = _context.Posts
            .Include(p => p.Creator)
            .Include(p => p.Likers)
            .FirstOrDefault(p => p.PostId == postId);

        if (post == null)
        {
            return NotFound();
        }

        User? loggedInUser = _context.Users.SingleOrDefault(u => u.UserId == loggedInUserId);

        var viewModel = new MyViewModel
        {
            Post = post,
            User = post.Creator,
            LoggedInUser = loggedInUser
        };

        return View(viewModel);
    }



    //Delete post
    [HttpPost("posts/{postId}/delete")]
    public IActionResult DeletePost(int postId)
    {
        Post? postToDelete = _context.Posts.SingleOrDefault(w => w.PostId == postId);
        if (postToDelete != null)
        {
            _context.Posts.Remove(postToDelete);
            _context.SaveChanges();
        }
        return RedirectToAction("Posts");
    }


    //Create Post
    //View
    [SessionCheck]
    [HttpGet("posts/new")]
    public IActionResult AddPost()
    {
        return View("AddPost");
    }

    // POST
    [HttpPost("posts/create")]
    public IActionResult CreatePost(Post newPost)
    {
        if (ModelState.IsValid)
        {
            int userId = (int)HttpContext.Session.GetInt32("UserId");

            newPost.UserId = userId;

            _context.Add(newPost);
            _context.SaveChanges();
            return RedirectToAction("OnePost", new { postId = newPost.PostId });
        }
        else
        {
            return View("AddPost");
        }
    }



    //Update Post
    //View
    [SessionCheck]
    [HttpGet("posts/edit/{postId}")]
    public IActionResult EditPost(int postId)
    {
        Post? postToEdit = _context.Posts.FirstOrDefault(e => e.PostId == postId);
        if (postToEdit != null)
        {
            return View(postToEdit);
        }
        else
        {
            return RedirectToAction("Posts");
        }
    }

    // POST
    [HttpPost("posts/update/{postId}")]
    public IActionResult UpdatePost(int postId, Post updatedPost)
    {
        int userId = (int)HttpContext.Session.GetInt32("UserId");

        Post? postToEdit = _context.Posts.FirstOrDefault(e => e.PostId == postId);

        if (postToEdit == null || postToEdit.UserId != userId)
        {
            return RedirectToAction("Posts");
        }

        if (ModelState.IsValid)
        {
            postToEdit.Image = updatedPost.Image;
            postToEdit.Title = updatedPost.Title;
            postToEdit.Medium = updatedPost.Medium;
            postToEdit.ForSale = updatedPost.ForSale;
            postToEdit.UpdatedAt = DateTime.Now;

            _context.SaveChanges();

            return RedirectToAction("OnePost", new { postId = postId });
        }

        return View("EditPost", updatedPost);
    }



    //-------------------------------- Dashboard End ----------------------------------



    //-------------------------------- Likes Start --------------------------

    // Create Like Associations 
    //All Posts page
    [HttpPost("like")]
    public IActionResult Like(int UserId, int PostId)
    {
        Like newLike = new Like
        {
            UserId = UserId,
            PostId = PostId
        };
        _context.Add(newLike);
        _context.SaveChanges();
        return RedirectToAction("Posts");
    }

    //OnePost Page
    [HttpPost("likeOne")]
    public IActionResult LikeOne(int UserId, int PostId)
    {
        Like newLike = new Like
        {
            UserId = UserId,
            PostId = PostId
        };
        _context.Add(newLike);
        _context.SaveChanges();
        return RedirectToAction("OnePost", new { postId = PostId });
    }

    // Remove Like Associations
    //All Posts page
    [HttpPost("like/{Id}/remove")]
    public IActionResult UnLike(int Id)
    {
        Like? likeToRemove = _context.Likes.SingleOrDefault(r => r.LikeId == Id);
        if (likeToRemove != null)
        {
            _context.Likes.Remove(likeToRemove);
            _context.SaveChanges();
        }
        return RedirectToAction("Posts");
    }

    //OnePost page 
    [HttpPost("UnLikeOne/{Id}")]
    public IActionResult UnLikeOne(int Id, int postId)
    {
        Like? likeToRemove = _context.Likes.SingleOrDefault(r => r.LikeId == Id);
        if (likeToRemove != null)
        {
            _context.Likes.Remove(likeToRemove);
            _context.SaveChanges();
        }

        return RedirectToAction("OnePost", new { postId = postId });
    }


    //-------------------------------- Likes End --------------------------



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