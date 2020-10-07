using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ITtrainees.MVC.Models
{
    public class User
    {
        [Display(Name = "Voornaam")]
        [Required(ErrorMessage = "U moet een voornaam invoeren")]
        public string FirstName { get; set; }

        [Display(Name = "Achternaam")]
        [Required(ErrorMessage = "U moet een achternaam invoeren")]
        public string LastName { get; set; }
    }
}
