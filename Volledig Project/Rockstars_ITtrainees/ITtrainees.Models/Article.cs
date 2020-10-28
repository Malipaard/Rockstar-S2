using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ITtrainees.Models
{
    public class Article
    {
        public int ArticleId { get; private set; }
        public string Title { get;  private set; }
        public string Author { get; private set; }
        public string Summary { get; private set; }
        //public string Content { get; private set; }
        //public string HeaderImage { get; private set; }


        public Article(string title, string author, string summary)
        {
            Title = title;
            Author = author;
            Summary = summary;
        }
        //public List<Review> Reviews { get; set; }



    }
}
