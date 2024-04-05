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
        // private readonly ILogger<LoginController> _logger;
        // private readonly string _connectionString = "Data Source=192.168.1.240\\SQLEXPRESS; database=RMS; User ID=CADBATCH01; Password=CAD@123pass; TrustServerCertificate=True;";

        // public LoginController(ILogger<LoginController> logger)
        // {
        //     _logger = logger;
        // }


        private readonly ApplicationDbContext _context;

        public LoginController(ApplicationDbContext context)
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

 
        [HttpGet]
        [Route("Login/Register")]

        public IActionResult Register()
        {
            return View("Register","_LayoutLogin");
        }


        [HttpPost]
        public IActionResult RegisterDB(UserRegistrationModel rmodel)
        {
            if (ModelState.IsValid)
            {
                // Check if the email is already registered
                var existingUser = _context.UserRegistration.FirstOrDefault(u => u.Email == rmodel.Email);
                if (existingUser != null)
                {
                    ModelState.AddModelError(string.Empty, "Email address is already registered.");
                    return View(rmodel);
                }

                // If not, proceed with registration
                var newUser = new UserRegistrationModel{
                    UserName = rmodel.UserName,
                    Email = rmodel.Email,
                    Password = rmodel.Password
                };

                _context.UserRegistration.Add(newUser);
                _context.SaveChanges();

                // _logger.LogInformation($"User {newUser.Email} registered successfully.");

                return View("Login");
            }

            else
            {
                return View(rmodel);
            }

        }
        
        [HttpGet]
        [Route("Login/Login")]
        public IActionResult Login()
        {
            return View();
        }


            [HttpPost]
    public IActionResult LoginDB(LoginModel lmodel)
    {
        if (ModelState.IsValid)
        {
            var user = _context.UserRegistration.FirstOrDefault(u => u.Email == lmodel.Email && u.Password == lmodel.Password);

            if (user != null)
            {
                // Authentication successful, redirect to a dashboard or home page
                return RedirectToAction("Dashboard", "Admin");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid email or password");
                return View(lmodel);
            }
        }
        else
        {
            return View(lmodel);
        }
    }

        [HttpPost]
        public IActionResult Logout()
        {
            // Clear session or cookie to indicate user logout
            HttpContext.Session.Clear();

            // _logger.LogInformation($"User logged out successfully.");

            return RedirectToAction("Index", "Login"); // Redirect to the homepage after logout
        }
        
  

    
        
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

