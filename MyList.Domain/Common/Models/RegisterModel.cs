using System.ComponentModel.DataAnnotations;

namespace MyList.Domain.Common.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Email not specified")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "User name not specified")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "First name not specified")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Password not specified")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Password incorrect")]
        public string PasswordConfirm { get; set; }
    }
}