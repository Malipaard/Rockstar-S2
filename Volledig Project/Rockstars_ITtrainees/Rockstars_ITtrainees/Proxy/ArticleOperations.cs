﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using 

namespace ITtrainees.MVC.Proxy
{
    public class ArticleOperations
    {
        public async Task<ActionResult> Index()
        {
            string apiUrl = "http://localhost:58764/api/values";

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    var table = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataTable>(data);

                }


            }
            return View();
        }
    }
}
