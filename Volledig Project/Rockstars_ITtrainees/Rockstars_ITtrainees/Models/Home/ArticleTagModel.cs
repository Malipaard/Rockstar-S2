using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITtrainees.MVC.Models.Home
{
    public class ArticleTagModel
    {
        public int TagId { get; set; }
        public string TagName { get; set; }
        public bool IsSelected { get; set; }

        public ArticleTagModel(int tagId, string tagName)
        {
            TagId = tagId;
            TagName = tagName;
        }
        public ArticleTagModel()
        {

        }
    }
}
