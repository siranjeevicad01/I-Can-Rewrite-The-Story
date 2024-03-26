using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using I_Can_Rewrite_The_Story.Models;
using Microsoft.Data.SqlClient;

namespace I_Can_Rewrite_The_Story.Controllers;

SqlConnection con=new SqlConnection();
    SqlCommand com=new SqlCommand();
    SqlDataReader? dr;

public class LoginController : Controller
{
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
    
    void ConnectionString(){
    con.ConnectionString = "Data Source=192.168.1.240\\SQLEXPRESS;Initial Catalog=RMS;User ID=CADBATCH01;Password=CAD@123pass;TrustServerCertificate=True;";
    }
    
    [HttpPost]
    public IActionResult RegisterDB(RegisterModel rmodel)
    {
        ConnectionString();
        con.Open();
        com.Connection=con;
        com.CommandText="insert into Usr_Reg(FirstName,LastName,User_name,Email_Id,Password) values(@FirstName,@LastName,@User_name,@Email_Id,@Password)";
        com.Parameters.AddwithValue("@FirstName",rmodel.FirstName);
        com.Parameters.AddwithValue("@LastName",rmodel.LastName);
        com.Parameters.AddwithValue("@User_name",rmodel.User_name);
        com.Parameters.AddwithValue("@Email_Id",rmodel.Email_Id);
        com.Parameters.AddwithValue("@Password",rmodel.Password);
        int rowAffected=cmd.ExecuteNonquery();
        if(rowAffected>0){
            con.Close();
            return RedirectToAction("Login");
        }
        else
        {
            con.Close();
            return view("Error");
        }
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
