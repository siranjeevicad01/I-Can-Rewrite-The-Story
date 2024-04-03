using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using I_Can_Rewrite_The_Story.Models; // Update with the correct namespace for your models
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace I_Can_Rewrite_The_Story.Controllers // Update with the correct namespace for your controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<AccountController> _logger;

        public AccountController(ApplicationDbContext context, ILogger<AccountController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(UserRegistration model)
        {
            if (ModelState.IsValid)
            {
                // Check if the email is already registered
                var existingUser = _context.Users.FirstOrDefault(u => u.Email == model.Email);
                if (existingUser != null)
                {
                    ModelState.AddModelError(string.Empty, "Email address is already registered.");
                    return View(model);
                }

                // If not, proceed with registration
                var newUser = new UserRegistration
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    Password = model.Password
                };

                _context.Users.Add(newUser);
                _context.SaveChanges();

                _logger.LogInformation($"User {newUser.Email} registered successfully.");

                return RedirectToAction("Login");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _context.Users.FirstOrDefault(u => u.Email == model.Email && u.Password == model.Password);
                if (user != null)
                {
                    // Log user in
                    // For example, you can set a session variable or cookie to indicate the user is logged in
                    HttpContext.Session.SetString("UserId", user.Id.ToString());

                    _logger.LogInformation($"User {user.Email} logged in successfully.");

                    return RedirectToAction("Index", "Home"); // Redirect to the homepage after login
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid email or password.");
                }
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Logout()
        {
            // Clear session or cookie to indicate user logout
            HttpContext.Session.Clear();

            _logger.LogInformation($"User logged out successfully.");

            return RedirectToAction("Index", "Login"); // Redirect to the homepage after logout
        }
    }
}
