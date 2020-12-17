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
using ITtrainees.MVC.Models.Home;

namespace ITtrainees.MVC.APITools
{
    public static class ArticleOperations
    {
        

        public static async Task Create(ArticleUploadViewModel model)
        {
            string encodedHeader = FileEncoder.EncodeImage(model.HeaderImage);
            string encodedContent = FileEncoder.EncodePDF(model.Content);
            Article article = new Article(0, model.Title, model.Author, model.Summary, model.Tag, encodedHeader, encodedContent);

            var stringContent = new StringContent(JsonConvert.SerializeObject(article), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await ApiClient.PostAsync($"article", stringContent);
            Console.WriteLine(response.StatusCode.ToString());
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

        public static async Task<Article> Get(int id)
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

        public static async void Update(Article article)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(article), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await ApiClient.PutAsync($"article", stringContent);
        }

        public static async void Delete(int id)
        {
            HttpResponseMessage response = await ApiClient.DeleteAsync($"article/{ id }");
        }

        public static async Task<int> GetArticleId(string author)
        {
            HttpResponseMessage response = await ApiClient.GetAsync($"article/{ author }");

            if (response.IsSuccessStatusCode)
            {
                var articleJSON = await response.Content.ReadAsStringAsync();
                var id = JsonConvert.DeserializeObject<int>(articleJSON);
                return id;
            }
            return -1;
        }
    }
}
