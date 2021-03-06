﻿using System;
using System.Collections.Generic;
using System.Text;
using ITtrainees.Models;

namespace ITtrainees.Interface.Interfaces
{
    public interface IAccountDAL
    {
        public Account GetAccount(string userName);
        public void CreateAccount(Account account);
        public void AddScore(Account account, int points);
    }
}
