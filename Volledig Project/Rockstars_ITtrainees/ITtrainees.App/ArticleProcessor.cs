using ITtrainees.Factory;
using ITtrainees.Interface.Interfaces;
using ITtrainees.Models;
using System.Collections.Generic;

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


        public static Article GetArticle(int id)
        {
            //return ArticleStorage[id];
            IArticleDAL dal = ArticleFactory.GetArticleDAL();
            var article = dal.GetArticle(id);
            return article;
        }

        public static List<Article> GetAll()
        {
            //return ArticleStorage;

            IArticleDAL dal = ArticleFactory.GetArticleDAL();
            List<Article> articles = dal.GetAll();
            return articles;
        }

        public static void Delete(int id)
        {
            IArticleDAL dal = ArticleFactory.GetArticleDAL();
            dal.DeleteArticle(id);
        }

        public static void Create(Article article)
        {
            IArticleDAL dal = ArticleFactory.GetArticleDAL();            
            dal.Create(article);
        }
    }
}
