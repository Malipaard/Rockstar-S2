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
        public virtual ICollection<Tag> Tags { get; set; }
        public string HeaderImage { get; set; }

        [JsonConstructor]
        public ArticleCard(int id, string title, string author, string summary, ICollection<Tag> tags, string headerImage) 
        {
            this.ArticleId = id;
            this.Title = title;
            this.Author = author;
            this.Summary = summary;
            this.Tags = tags;
            this.HeaderImage = headerImage;
        }

        public ArticleCard(Article article)
        {
            this.ArticleId = article.ArticleId;
            this.Title = article.Title;
            this.Author = article.Author;
            this.Summary = article.Summary;
            this.Tags = article.Tags;
            this.HeaderImage = article.HeaderImage;
        }
    }
}
