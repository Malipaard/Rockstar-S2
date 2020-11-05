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
        public string Title { get;  set; }
        public string Author { get; set; }
        public string Summary { get; set; }
        public string Tag { get; set; }
        //public string Content { get; private set; }
        //public string HeaderImage { get; private set; }

        //public List<Review> Reviews { get; set; }

    }
}
