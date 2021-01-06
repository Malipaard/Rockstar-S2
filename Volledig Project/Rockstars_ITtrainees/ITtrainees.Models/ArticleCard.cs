using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Principal;
using System.Text;

namespace ITtrainees.Models
{
    public class ArticleCard
    {
        public int ArticleId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Summary { get; set; }
        public string Tag { get; set; }
        public string HeaderImage { get; set; }

        [JsonConstructor]
        public ArticleCard(int id, string title, string author, string summary, string tag, string headerImage) 
        {
            this.ArticleId = id;
            this.Title = title;
            this.Author = author;
            this.Summary = summary;
            this.Tag = tag;
            this.HeaderImage = headerImage;
        }

        public ArticleCard(Article article)
        {
            this.ArticleId = article.ArticleId;
            this.Title = article.Title;
            this.Author = article.Author;
            this.Summary = article.Summary;
            this.Tag = article.Tag;
            this.HeaderImage = article.HeaderImage;
        }
    }
}
