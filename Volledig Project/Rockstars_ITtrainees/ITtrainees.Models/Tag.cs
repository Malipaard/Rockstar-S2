using System;
using System.Collections.Generic;
using System.Text;

namespace ITtrainees.Models
{
    public class Tag
    {
        public int TagId { get; set; }
        public string TagName { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
        
        public Tag()
        {

        }

        public Tag(int tagId, string tagName)
        {
            this.TagId = tagId;
            this.TagName = tagName;
        }
    }
}
