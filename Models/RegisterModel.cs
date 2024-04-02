using System.ComponentModel.DataAnnotations;

namespace I_Can_Rewrite_The_Story.Models;

public class RegisterDB
{
    [Required(ErrorMessage = "User name is required")]
    public string User_name { get; set; }

    [Required(ErrorMessage = "Email address is required")]
    [EmailAddress(ErrorMessage = "Invalid email address")]
    public string Email_Id { get; set; }

    [Required(ErrorMessage = "Password is required")]
    [DataType(DataType.Password)]
    public string Create_Password { get; set; }

    [Required(ErrorMessage = "Please repeat your password")]
    [Compare("Create_Password", ErrorMessage = "Passwords do not match")]
    [DataType(DataType.Password)]
    public string Repeat_Password { get; set; }
}