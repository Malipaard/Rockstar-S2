using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITtrainees.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ITtrainees.Logic
{
    [Route("api/article")]
    [ApiController]
    public class ArticleAPI : ControllerBase
    {
        static List<Article> ArticleStorage = new List<Article>() { new Article {
            Title = "TestArtikel",
            Author = "Ruud",
            Summary = "GEFELICITEERD JE HEBT HET TESTARTIKEL GELADEN"
        }, new Article {
            Title = "Artikel",
            Author = "Pieter",
            Summary = "teeeeeeeeeeekkksssttt"
        } };

        //api/article
        [HttpGet]
        public IEnumerable<Article> GetAllArticles()
        {
            return ArticleStorage;
        }

        //api/article/{id}
        [HttpGet("{id}")]
        public ActionResult<Article> GetArticle(int id)
        {
            return ArticleStorage[id];
        }

        //api/article
        [HttpPost]
        public void PostArticle(Article article)
        {
            ArticleStorage.Add(article);
        }
    }
}
