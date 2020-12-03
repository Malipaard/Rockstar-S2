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




        public string Password { get; set; }

        public Account(int accountID, string name, int points, bool isAdmin, string pass)
        {
            this.AccountID = accountID;
            this.Name = name;
            this.Points = points;
            this.IsAdmin = isAdmin;
            this.Password = pass;
        }

        public Account(string name, int points, bool isAdmin, string pass)
        {
            this.Name = name;
            this.Points = points;
            this.IsAdmin = isAdmin;
            this.Password = pass;
        }
    }
}