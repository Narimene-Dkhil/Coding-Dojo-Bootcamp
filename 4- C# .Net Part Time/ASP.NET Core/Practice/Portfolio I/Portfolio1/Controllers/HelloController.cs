using Microsoft.AspNetCore.Mvc;
namespace ProjectName.Controllers;
public class HelloController : Controller
{
    // Route declaration Option A
    // This will go to "localhost:5162"
    [HttpGet]
    [Route("")]
    public string Index()
    {
        return "This is my index!";
    }
    
    // Route declaration Option B
    // This will go to "localhost:5162/projects"
    [HttpGet("/projects")]
    public string Projects()
    {
        return "These are my projects";
    }

    // Route declaration Option C
    // This will go to "localhost:5162/contact"
    [HttpGet("/contact")]
    public string Contact()
    {
        return "This is my Contact!";
    }
}