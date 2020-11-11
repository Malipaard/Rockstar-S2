using ITtrainees.Models;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using static ITtrainees.MVC.APIProxies.APIHelper;

namespace ITtrainees.MVC.APIProxies
{
    public class ProxyArticle
    {
        public int ArticleId { get; private set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Summary { get; set; }

        public ProxyArticle(int id)
        {
            ArticleId = id;
        }

        public async Task<ProxyArticle> getArticle()
        {
            HttpResponseMessage response = await ApiClient.GetAsync($"article/0");

            if (response.IsSuccessStatusCode)
            {
                Article article = await JsonSerializer.DeserializeAsync<Article>(await response.Content.ReadAsStreamAsync());

                this.Title = article.Title;
                this.Author = article.Author;
                this.Summary = article.Summary;

                return this;
            }

            return null;
        }
    }
}
