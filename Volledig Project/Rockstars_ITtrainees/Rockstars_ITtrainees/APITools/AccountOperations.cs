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

        public static async Task<Account> Get(string userName)
        {
            HttpResponseMessage response = await ApiClient.GetAsync($"account/{ userName }");
            if (response.IsSuccessStatusCode)
            {
                var accountJSON = await response.Content.ReadAsStringAsync();
                var account = JsonConvert.DeserializeObject<Account>(accountJSON);
                return account;
            }
            return null;
        }

        public static async Task<Account> GetId(int id)
        {
            HttpResponseMessage response = await ApiClient.GetAsync($"account/{ id }");
            if (response.IsSuccessStatusCode)
            {
                var accountJSON = await response.Content.ReadAsStringAsync();
                var account = JsonConvert.DeserializeObject<Account>(accountJSON);
                return account;
            }
            return null;
        }

    }
}
