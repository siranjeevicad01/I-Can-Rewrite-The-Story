using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using I_Can_Rewrite_The_Story.Models;
using Microsoft.Data.SqlClient;
using System.Diagnostics;

namespace I_Can_Rewrite_The_Story.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;
        // private readonly string _connectionString = "Data Source=192.168.1.240\\SQLEXPRESS; database=RMS; User ID=CADBATCH01; Password=CAD@123pass; TrustServerCertificate=True;";

        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
        }


        private readonly ApplicationDbContext _context;

        public LoginController(ILogger<LoginController> logger, ApplicationDbContext context)
        {
            _context = context;
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

 
        // [HttpGet]
        // public IActionResult Register()
        // {
        //     return View();
        // }
        
        // [HttpPost]
        // public IActionResult Register(RegisterDB rmodel)
        // {
        //     if (!ModelState.IsValid)
        //     {
        //         // If the model is not valid, return the Register view with validation errors
        //         return View(rmodel);
        //     }
            
        //     try
        //     {
        //         using (SqlConnection con = new SqlConnection(_connectionString))
        //         {
        //             con.Open();
        //             using (SqlCommand com = con.CreateCommand())
        //             {
        //                 com.CommandText = "INSERT INTO Usr_Reg (User_name, Email_Id, Create_Password, Repeat_Password) VALUES (@User_name, @Email_Id, @Create_Password, @Repeat_Password)";
        //                 com.Parameters.AddWithValue("@User_name", rmodel.User_name);
        //                 com.Parameters.AddWithValue("@Email_Id", rmodel.Email_Id);
        //                 com.Parameters.AddWithValue("@Create_Password", rmodel.Create_Password);
        //                 com.Parameters.AddWithValue("@Repeat_Password", rmodel.Repeat_Password);
        //                 int rowsAffected = com.ExecuteNonQuery();

        //                 if (rowsAffected > 0)
        //                 {
        //                     return RedirectToAction("Login");
        //                 }
        //                 else
        //                 {
        //                     return View("Error");
        //                 }
        //             }
        //         }
        //     }
        //     catch (Exception ex)
        //     {
        //         _logger.LogError($"An error occurred while registering user: {ex.Message}");
        //         return View("Error");
        //     }
        // }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
