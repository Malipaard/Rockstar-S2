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
                dbArticle.HeaderImage = article.HeaderImage;
                dbArticle.Content = article.Content;

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


        public List<Models.ArticleCard> GetAllCards()
        {
            using (var context = new ArticlesContext())
            {
                var articles = context.Articles.ToList();

                //articles omzetten naar cards
                List<Models.ArticleCard> cards = new List<Models.ArticleCard>();
                foreach (Models.Article article in articles)
                {
                    Models.ArticleCard card = new Models.ArticleCard(article);
                    cards.Add(card);
                }
                return cards;
            }
        }

        public Models.ArticleCard GetCard(int id)
        {
            using (var context = new ArticlesContext())
            {
                var card = new Models.ArticleCard(context.Articles.Single(a => a.ArticleId == id));
                return card;
            }
        }
    }
}
