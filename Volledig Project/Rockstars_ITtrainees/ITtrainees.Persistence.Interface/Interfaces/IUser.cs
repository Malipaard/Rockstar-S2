using System;
using System.Collections.Generic;
using System.Text;

namespace ITtrainees.Persistence.Interface.Interfaces
{
    public interface IUser
    {
        int UserId { get; }
        string FirstName { get; set; }
        string LastName { get; set; }
    }
}