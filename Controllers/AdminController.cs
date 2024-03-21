using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using I_Can_Rewrite_The_Story.Models;

namespace I_Can_Rewrite_The_Story.Controllers;

public class AdminController : Controller
{
    private readonly ILogger<AdminController> _logger;

    public AdminController(ILogger<AdminController> logger)
    {
        _logger = logger;
    }

    public IActionResult Dashboard()
    {
        return View();
    }

    public IActionResult ManageUser()
    {
        return View();
    }

    public IActionResult MyTask()
    {
        return View();
    }

    public IActionResult ManageSession()
    {
        return View();
    }

    public IActionResult Reports()
    {
        return View();
    }

    public IActionResult Settings()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
