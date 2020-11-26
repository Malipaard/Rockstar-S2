using System;
using System.Collections.Generic;
using System.Text;

namespace ITtrainees.Models
{
    public class Account
    {
        public int AccountID { get; set; }
        public string Name { get; set; }
        public int Points { get; set; }
        public bool IsAdmin { get; set; }

        public Account(int accountID, string name, int points, bool isAdmin)
        {
            this.AccountID = accountID;
            this.Name = name;
            this.Points = points;
            this.IsAdmin = isAdmin;
        }
    }
}
