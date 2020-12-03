using ITtrainees.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;
using static ITtrainees.MVC.APITools.APIHelper;
using System.Collections.Generic;
using System.Text;

namespace ITtrainees.MVC.APITools
{
    public class AccountOperations
    {
        public static async void Create(Account account)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(account), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await ApiClient.PostAsync($"account", stringContent);
        }
    }
}
