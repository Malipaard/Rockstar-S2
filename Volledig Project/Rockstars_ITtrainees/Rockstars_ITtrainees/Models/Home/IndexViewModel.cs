using ITtrainees.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITtrainees.MVC.Models.Home
{
    public class IndexViewModel
    {
        public List<Article> RecentArticles { get; set; }
        public List<Article> FilteredArticles { get; set; }
    }
}
