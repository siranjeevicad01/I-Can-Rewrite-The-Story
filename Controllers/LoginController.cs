using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using I_Can_Rewrite_The_Story.Models;

namespace I_Can_Rewrite_The_Story.Controllers;

public class LoginController : Controller
{
    SqlConnection con = new SqlConnection();
    SqlCommand cmd = new SqlCommand();
    SqlDataReader dr;

    private readonly ILogger<LoginController> _logger;

    public LoginController(ILogger<LoginController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult AboutUs()
    {
        return View();
    }

    public IActionResult Services()
    {
        return View();
    }

    public IActionResult ContactUs()
    {
        return View();
    }

    public IActionResult Login()
    {
        return View();
    }
    
    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }
    void ConnectionSring(){
        con.ConnectionSring="data source=192.168.1.240\SQLEXPRESS;database=RMS; User Id=CADBATCH01;Password=CAD@123pass; TrustServerCertificate=True;"
    }
    
    [HttpPost]
    public IActionResult RegisterDB(RegisterModel rmodel)
    {
        ConnectionSring();
        con.Open();
        cmd.Connection=con;
        cmd.CommandText
        return View();
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
