using System;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Principal;
using System.Text;

namespace ITtrainees.Models
{
    public class Article
    {
        public int ArticleId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Summary { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
        public string HeaderImage { get; set; }
        public string Content { get; set; }

        //public string Content { get; set; }
        //public string HeaderImage { get; private set; }

        public Article(int id, string title, string author, string summary, ICollection<Tag> tags, string headerImage, string content) 
        {
            this.ArticleId = id;
            this.Title = title;
            this.Author = author;
            this.Summary = summary;
            this.Tags = tags;
            this.HeaderImage = headerImage;
            this.Content = content;
        }

        public Article()
        {

        }
        //public List<Review> Reviews { get; set; }

    }
}
