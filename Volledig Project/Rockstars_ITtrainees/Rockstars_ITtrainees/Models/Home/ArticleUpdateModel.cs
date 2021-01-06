using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ITtrainees.Models;

namespace ITtrainees.MVC.Models.Home
{
    public class ArticleUpdateModel
    {
        [Required]
        public int ArticleId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string Summary { get; set; }
        [Required]
        public string Tag { get; set; }
        
        public IFormFile HeaderImage { get; set; }
        [Required]
        public string HeaderImageString { get; set; }

        [Required]
        public string Content { get; set; }

        public ArticleUpdateModel(Article article)
        {
            this.ArticleId = article.ArticleId;
            this.Title = article.Title;
            this.Author = article.Author;
            this.Summary = article.Summary;
            this.Tag = article.Tag;
            this.HeaderImageString = article.HeaderImage;
            this.Content = article.Content;
        }

        public ArticleUpdateModel()
        {
 
        }
    }

}
