using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using I_Can_Rewrite_The_Story.Models;

namespace I_Can_Rewrite_The_Story.Controllers;

public class SeniorController : Controller
{
    private readonly ILogger<SeniorController> _logger;

    public SeniorController(ILogger<SeniorController> logger)
    {
        _logger = logger;
    }

    public IActionResult Dashboard()
    {
        return View();
    }

    public IActionResult Profile()
    {
        return View();
    }

    public IActionResult MyTask()
    {
        return View();
    }

    public IActionResult ViewSession()
    {
        return View();
    }

    public IActionResult Reports()
    {
        return View();
    }

    public IActionResult Projects()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
