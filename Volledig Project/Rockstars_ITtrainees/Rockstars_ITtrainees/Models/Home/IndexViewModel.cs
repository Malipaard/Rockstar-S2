using ITtrainees.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITtrainees.MVC.Models.Home
{
    public class IndexViewModel
    {
        public List<ArticleCard> RecentArticles { get; set; }
        public List<ArticleCard> FilteredArticles { get; set; }
        public List<ITtrainees.Models.Tag> Tags { get; set; }
    }
}
