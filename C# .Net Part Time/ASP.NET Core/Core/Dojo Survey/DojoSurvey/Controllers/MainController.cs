using System;
using Microsoft.AspNetCore.Mvc;

namespace DojoSurvey.Controllers
{
    public class MainController : Controller
    {
        [HttpGet]
        [Route("")]
        public ViewResult Form()
        {
            return View("Form");
        }

        [HttpPost("results")]
        public IActionResult postForm(string Name, string DojoLocation, string FavoriteLanguage, string Comment)
        {
            ViewBag.Name = Name;
            ViewBag.DojoLocation = DojoLocation;
            ViewBag.FavoriteLanguage = FavoriteLanguage;
            ViewBag.Comment = Comment;
            return View("Display");
        }

        [HttpGet("Display")]
        public IActionResult Display()
        {
            return View("Display");
        }
    }
} 