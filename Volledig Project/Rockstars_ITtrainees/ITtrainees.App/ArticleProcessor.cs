using System;
using System.Collections.Generic;
using System.Text;
using ITtrainees.Models;

namespace ITtrainees.Logic
{
    public static class ArticleProcessor
    {
        //class is volledig tijdelijk

        static List<Article> ArticleStorage = new List<Article>() { new Article {
            Title = "Test Artikel",
            Author = "Ruud",
            Summary = "GEFELICITEERD JE HEBT HET TESTARTIKEL GELADEN"
        } };

        public static string Save(Article article)
        {
            ArticleStorage.Add(article);
            return $"Artikel \"{ article.Title }\" is opgeslagen!";
        }

        public static Article Get(string title)
        {
            for (var i = 0; i < ArticleStorage.Count; i++)
            {
                Article article = ArticleStorage[i];
                if (article.Title == title)
                {
                    return article;
                }
            }
            return null;
        }

        public static List<Article> GetAll()
        {
            return ArticleStorage;
        }
    }
}
