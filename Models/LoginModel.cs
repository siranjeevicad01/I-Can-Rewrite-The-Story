using System.ComponentModel.DataAnnotations;

namespace I_Can_Rewrite_The_Story.Models 
{
    public class LoginModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Email address is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        public bool RememberMe { get; set; }
    }
}
