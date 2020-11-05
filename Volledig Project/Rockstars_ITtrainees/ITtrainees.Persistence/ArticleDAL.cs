using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ITtrainees.Interface.Interfaces;

namespace ITtrainees.DataAcces
{
    public class ArticleDAL : IArticleDAL
    {
        public List<Models.Article> GetAll()
        {
            using (var context = new ArticlesContext())
            {
                var articles = context.Articles.ToList();
                return articles;
            }
        }

        public void DeleteArticle(int id)
        {
            using (var context = new ArticlesContext())
            {
                var article = context.Articles.Single(a => a.ArticleId == id);
                context.Articles.Attach(article);
                context.Articles.Remove(article);
                context.SaveChanges();
            }    
        }

        public void Create(Models.Article article)
        {
            throw new NotImplementedException();
        }
    }
}
