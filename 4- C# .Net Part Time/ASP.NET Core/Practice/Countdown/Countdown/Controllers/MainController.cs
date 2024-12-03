using Microsoft.AspNetCore.Mvc;
namespace Portfolio_II.Controllers;   
public class MainController : Controller
{ 

    [HttpGet("")]
    public ViewResult Index()
    {
        return View("Index");
    }
    

}