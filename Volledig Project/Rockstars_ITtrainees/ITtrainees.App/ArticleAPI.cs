using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITtrainees.Factory;
using ITtrainees.Interface.Interfaces;
using ITtrainees.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ITtrainees.Logic
{
    [Route("api/article")]
    [ApiController]
    public class ArticleAPI : ControllerBase
    {
        //api/article
        [HttpPost]
        public void CreateArticle(Article article)
        {
            IArticleDAL dal = ArticleFactory.GetArticleDAL();
            dal.Create(article);
        }

        //api/article/{id}
        [HttpGet("{id:int:min(1)}")]
        public Article GetArticle(int id)
        {
            IArticleDAL dal = ArticleFactory.GetArticleDAL();
            var article = dal.GetArticle(id);
            return article;
        }

        //api/article
        [HttpGet]
        public IEnumerable<Article> GetAllArticles()
        {
            IArticleDAL dal = ArticleFactory.GetArticleDAL();
            List<Article> articles = dal.GetAll();
            return articles;
        }
        
        //api/article/{id}
        [HttpDelete("{id:int:min(1)}")]
        public void Delete(int id)
        {
            IArticleDAL dal = ArticleFactory.GetArticleDAL();
            dal.DeleteArticle(id);
        }
    }
}
