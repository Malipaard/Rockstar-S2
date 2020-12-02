using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITtrainees.MVC.Models.Home
{
    public class ArticleUploadViewModel
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Summary { get; set; }
        public string Tag { get; set; }
        public string HeaderImage { get; set; }
    }
}
