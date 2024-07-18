using Microsoft.AspNetCore.Mvc;
namespace YourNamespace.Controllers;
public class RazorController : Controller
{
    [HttpGet]
    [Route("")]
    public ViewResult Index()
    {
        return View("Index");
    }
}