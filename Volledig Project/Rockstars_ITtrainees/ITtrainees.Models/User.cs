using System;

namespace ITtrainees.Models
{
    public class User
    {
        public int UserId { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }


        public string FullName()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
