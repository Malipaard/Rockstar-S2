using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ITtrainees.Interface.Interfaces;
using ITtrainees.Models;

namespace ITtrainees.DataAcces
{
    public class AccountDAL : IAccountDAL
    {
        public void AddScore(Account account, int points)
        {
            using (var context = new ArticlesContext())
            {
                var dbUser = context.Accounts.Single(a => a.AccountID == account.AccountID);

                dbUser.Points = dbUser.Points + points;

                context.SaveChanges();
            }
        }

        public void CreateAccount(Account account)
        {
            using (var context = new ArticlesContext())
            {
                account.Points = 0;
                context.Accounts.Add(account);
                context.SaveChanges();
            }
        }

        public Account GetAccount(int id)
        {
            using (var context = new ArticlesContext())
            {
                var account = context.Accounts.Single(a => a.AccountID == id);
                return account;
            }
        }
    }
}
