using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ITtrainees.Interface.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ITtrainees.DataAcces
{
    public class ArticleDAL : IArticleDAL
    {
        public List<Models.Article> GetAll()
        {
            using (var context = new ArticlesContext())
            {
                var articles = context.Articles.Include(a => a.Tags).ToList();
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

                foreach(var tag in article.Tags)
                {
                    context.Entry(tag).State = EntityState.Unchanged;
                }
                context.SaveChanges();
            }
        }

        public void Update(Models.Article article)
        {
            using (var context = new ArticlesContext())
            {
                var dbArticle = context.Articles.Include(a => a.Tags).Single(a => a.ArticleId == article.ArticleId);

                dbArticle.Author = article.Author;
                dbArticle.Summary = article.Summary;
                dbArticle.Tags = article.Tags;
                dbArticle.Title = article.Title;
                dbArticle.HeaderImage = article.HeaderImage;
                dbArticle.Content = article.Content;

                foreach (var tag in article.Tags)
                {
                    context.Entry(tag).State = EntityState.Unchanged;
                }
                context.SaveChanges();
            }
        }

        public Models.Article GetArticle(int id)
        {
            using (var context = new ArticlesContext())
            {
                var article = context.Articles.Include(a => a.Tags).Single(a => a.ArticleId == id);
                return article;
            }
        }


        public List<Models.ArticleCard> GetAllCards()
        {
            using (var context = new ArticlesContext())
            {
                var articles = context.Articles.Include(a => a.Tags).ToList();

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
                var card = new Models.ArticleCard(context.Articles.Include(a => a.Tags).Single(a => a.ArticleId == id));
                return card;
            }
        }

        public int GetArticleId (string author)
        {
            using (var context = new ArticlesContext())
            {
                var id = context.Articles.OrderByDescending(p => p.ArticleId).Where(p => p.Author == author).Select(p => p.ArticleId).FirstOrDefault();
                return id;
            }
        }
    }
}
