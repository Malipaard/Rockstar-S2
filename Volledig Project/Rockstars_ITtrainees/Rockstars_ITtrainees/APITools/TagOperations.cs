using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ITtrainees.Models;
using ITtrainees.MVC.Models.Home;
using Newtonsoft.Json;
using static ITtrainees.MVC.APITools.APIHelper;
using ITtrainees.MVC.APITools;
using System.Text;

namespace ITtrainees.MVC.APITools
{
    public class TagOperations
    {
        public static async void Create(ArticleUploadViewModel model)
        {
            string encodedHeader = FileEncoder.EncodeImage(model.HeaderImage);
            Article article = new Article(0, model.Title, model.Author, model.Summary, model.Tag, encodedHeader, model.Content); ;

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
    }
}
