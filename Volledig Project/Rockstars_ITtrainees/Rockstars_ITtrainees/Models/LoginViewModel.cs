using System.ComponentModel.DataAnnotations;

namespace ITtrainees.MVC.Models
{
    public class LoginViewModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }

    }
}
