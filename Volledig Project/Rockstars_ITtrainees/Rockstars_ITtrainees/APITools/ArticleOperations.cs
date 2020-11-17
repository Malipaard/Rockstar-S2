using ITtrainees.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;
using static ITtrainees.MVC.APITools.APIHelper;

namespace ITtrainees.MVC.APITools
{
    public static class ArticleOperations
    {
        public static async Task<Article> getArticle(int id)
        {
            HttpResponseMessage response = await ApiClient.GetAsync($"article/{ id }");
            if (response.IsSuccessStatusCode)
            {
                var articleJSON = await response.Content.ReadAsStringAsync();
                var article = JsonConvert.DeserializeObject<Article>(articleJSON);
                return article;
            }
            return null;
        }
    }
}
