using System.ComponentModel.DataAnnotations;

namespace I_Can_Rewrite_The_Story.Models;

public class RegisterModel
{
    public string User_name { get; set; }
    public string Email_Id { get; set; }
    public string Create_Password { get; set; }
    public string Repeat_Password { get; set; }
}