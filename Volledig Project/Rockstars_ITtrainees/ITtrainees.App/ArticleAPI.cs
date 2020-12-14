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
        public IActionResult Create(Article article)
        {
            IArticleDAL dal = ArticleFactory.GetArticleDAL();
            dal.Create(article);
            return Accepted();
        }

        //api/article/{id}
        [HttpGet("{id:int:min(1)}")]
        public Article Get(int id)
        {
            try { 
            IArticleDAL dal = ArticleFactory.GetArticleDAL();
            var article = dal.GetArticle(id);
            return article;
            }
            catch
            {
                return null;
            }
        }

        //api/article
        [HttpGet]
        public IEnumerable<Article> GetAll()
        {
            IArticleDAL dal = ArticleFactory.GetArticleDAL();
            List<Article> articles = dal.GetAll();
            return articles;
        }

        //api/article
        [HttpPut]
        public IActionResult Update(Article article)
        {
            IArticleDAL dal = ArticleFactory.GetArticleDAL();
            dal.Update(article);
            return Accepted();
        }

        //api/article/{id}
        [HttpDelete("{id:int:min(1)}")]
        public IActionResult Delete(int id)
        {
            IArticleDAL dal = ArticleFactory.GetArticleDAL();
            dal.DeleteArticle(id);
            return Accepted();
        }
    }
}
