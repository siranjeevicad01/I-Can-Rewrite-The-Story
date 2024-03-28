using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using I_Can_Rewrite_The_Story.Models;
using Microsoft.Data.SqlClient;

namespace I_Can_Rewrite_The_Story.Controllers;



public class LoginController : Controller
{
    private readonly ILogger<LoginController> _logger;

    SqlConnection con=new SqlConnection();
    SqlCommand com=new SqlCommand();
    SqlDataReader? dr;

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
    con.ConnectionString = "Data Source=192.168.1.240\\SQLEXPRESS; database=RMS; User ID=CADBATCH01; Password=CAD@123pass; TrustServerCertificate=True;";
    }
    
    [HttpPost]
    public IActionResult RegisterDB(RegisterModel rmodel)
    {
        ConnectionString();
        con.Open();
        com.Connection=con;
        com.CommandText="insert into Usr_Reg(User_name,Email_Id,Create_Password,Repeat_Password) values(@User_name,@Email_Id,@Create_Password,@Repeat_Password)";
        com.Parameters.AddWithValue("@User_name",rmodel.User_name);
        com.Parameters.AddWithValue("@Email_Id",rmodel.Email_Id);
        com.Parameters.AddWithValue("@Create_Password",rmodel.Create_Password);
        com.Parameters.AddWithValue("@Repeat_Password",rmodel.Repeat_Password);

        int rowAffected=com.ExecuteNonQuery();
        if(rowAffected>0){
            con.Close();
            return RedirectToAction("Login");
        }
        else
        {
            con.Close();
            return View("Error");
        }
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
