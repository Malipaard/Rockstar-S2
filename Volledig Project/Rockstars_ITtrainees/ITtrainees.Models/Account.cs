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
    }
}   
