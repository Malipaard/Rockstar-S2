using System;
using ITtrainees.Persistence.Interface.Interfaces;

namespace ITtrainees.App
{
    public class User : IUser
    {
        public int UserId { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
