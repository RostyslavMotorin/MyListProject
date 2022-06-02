using System.ComponentModel.DataAnnotations;

namespace MyList.Data.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Email not specified")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password not specified")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}