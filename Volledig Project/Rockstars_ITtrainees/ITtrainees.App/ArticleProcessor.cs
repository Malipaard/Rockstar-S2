using System;
using System.Collections.Generic;
using System.Text;
using ITtrainees.Models;

namespace ITtrainees.Logic
{
    public static class ArticleProcessor
    {
        //class is volledig tijdelijk

        public static List<Article> ArticleStorage = new List<Article>() {
            new Article
            {
                ArticleId = 0,
                Title = "Test",
                Author = "cas",
                Summary = "test"
            }
        };   

        public static void Save(Article article)
        {            
            article.ArticleId = ArticleStorage.Count;
            ArticleStorage.Add(article);
        }    

        public static Article Get(int id)
        {
            return ArticleStorage[id];
        }

        public static List<Article> GetAll()
        {
            return ArticleStorage;
        }
    }
}
