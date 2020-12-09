using ITtrainees.Interface.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using ITtrainees.DataAcces;

namespace ITtrainees.Factory
{
    public class AccountFactory
    {
        public static IAccountDAL GetAccountDAL()
        {
            return new AccountDAL();
        }
    }
}
