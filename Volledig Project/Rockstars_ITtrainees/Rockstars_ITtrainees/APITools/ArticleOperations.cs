using ITtrainees.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;
using static ITtrainees.MVC.APITools.APIHelper;
using System.Collections.Generic;

namespace ITtrainees.MVC.APITools
{
    public static class ArticleOperations
    {
        public static async void CreateArticle(Article article)
        {
            var stringContent = new StringContent(article.ToString());
            HttpResponseMessage response = await ApiClient.PostAsync($"article", stringContent);
        }

        public static async Task<List<Article>> GetAll()
        {
            HttpResponseMessage response = await ApiClient.GetAsync($"article");
            if (response.IsSuccessStatusCode)
            {
                var listJSON = await response.Content.ReadAsStringAsync();
                var list = JsonConvert.DeserializeObject<List<Article>>(listJSON);
                return list;
            }
            return null;
        }

        public static async Task<Article> GetArticle(int id)
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

        public static async void DeleteArticle(int id)
        {
            HttpResponseMessage response = await ApiClient.DeleteAsync($"article{ id }");
        }
    }
}
