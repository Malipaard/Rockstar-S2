using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITtrainees.Models;

namespace ITtrainees.MVC.Models.Home
{
    public class ArticleViewViewModel
    {
        public int ArticleId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Summary { get; set; }
        public string Tag { get; set; }
        public string HeaderImage { get; set; }
        public string Content { get; set; }
        public List<Question> Questions { get; set; }
        public List<string> GivenAnswers { get; set; }

    }
}
