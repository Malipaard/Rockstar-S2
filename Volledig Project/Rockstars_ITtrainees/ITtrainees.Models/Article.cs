using System;
using System.Collections.Generic;
using System.Text;

namespace ITtrainees.Models
{
    public class Article
    {
        public int ArticleId { get; private set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Summary { get; set; }
        //public List<Review> Reviews { get; set; }
    }
}
