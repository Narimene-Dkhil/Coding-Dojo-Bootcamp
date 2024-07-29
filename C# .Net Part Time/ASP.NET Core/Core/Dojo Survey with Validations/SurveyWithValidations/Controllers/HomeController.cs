﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SurveyWithValidations.Models;

namespace SurveyWithValidations.Controllers;

public class HomeController : Controller
{
    static UserSurvey? user;
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

    [HttpPost("")]
    public IActionResult Create(UserSurvey newUser)
    {
        if(ModelState.IsValid)
        {
            user=newUser;
            return RedirectToAction("Results");
        }
        else{
            return View("Index");
        }
    }

    [HttpGet("results")]
    public IActionResult Results()
    {
        return View(user);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}