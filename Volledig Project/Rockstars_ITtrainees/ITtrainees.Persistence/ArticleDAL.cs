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
                try { 
                var article = context.Articles.Single(a => a.ArticleId == id);
                context.Articles.Attach(article);
                context.Articles.Remove(article);
                context.SaveChanges();
                }
                catch
                {
                    return;
                }
            }    
        }

        public void Create(Models.Article article)
        {
            using (var context = new ArticlesContext())
            {
                context.Articles.Add(article);
                context.SaveChanges();
            }
        }

        public void Update(Models.Article article)
        {
            using (var context = new ArticlesContext())
            {
                var dbArticle = context.Articles.Single(a => a.ArticleId == article.ArticleId);

                dbArticle.Author = article.Author;
                dbArticle.Summary = article.Summary;
                dbArticle.Tag = article.Tag;
                dbArticle.Title = article.Title;

                context.SaveChanges();
            }
        }

        public Models.Article GetArticle(int id)
        {
            using (var context = new ArticlesContext())
            {
                var article = context.Articles.Single(a => a.ArticleId == id);
                return article;
            }
        }
    }
}
