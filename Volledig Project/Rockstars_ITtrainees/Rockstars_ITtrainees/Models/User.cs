using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITtrainees.MVC.Models
{
    public class User
    {
        public int UserId { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
