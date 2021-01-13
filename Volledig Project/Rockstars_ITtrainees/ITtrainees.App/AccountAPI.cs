using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITtrainees.Factory;
using ITtrainees.Interface.Interfaces;
using ITtrainees.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ITtrainees.Logic
{
    [Route("api/account")]
    [ApiController]
    public class AccountAPI : ControllerBase
    {
        [HttpPost]
        public IActionResult Create(Account account)
        {
            IAccountDAL dal = AccountFactory.GetAccountDAL();
            dal.CreateAccount(account);
            return Accepted();
        }

        [HttpGet("{userName}")]
        public Account Get(string userName)
        {
            try
            {
                IAccountDAL dal = AccountFactory.GetAccountDAL();
                var account = dal.GetAccount(userName);
                return account;
            }
            catch
            {
                return null;
            }
        }

        [HttpGet]
        public IEnumerable<Account> GetAll()
        {
            IAccountDAL dal = AccountFactory.GetAccountDAL();
            List<Account> accounts = dal.GetAll();
            return accounts;
        }
    }
}
