using System.ComponentModel.DataAnnotations;

namespace ITtrainees.MVC.Models
{
    public class RegisterViewModel
    {   
        [Required]
        public string Username { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }
        [Required]
        [MinLength(6)]
        public string PasswordCheck { get; set; }

        [Required]
        public bool IsAdmin { get; set; } //kan beter een enmun voor latere uitbreiding

        [Required]
        public int Rockstars { get; set; } //aantal startpunten kiezen 

    }
}
