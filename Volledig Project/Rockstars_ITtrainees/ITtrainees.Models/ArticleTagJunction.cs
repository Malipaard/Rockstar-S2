using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ITtrainees.Models
{
    public class ArticleTagJunction
    {
        [Key, Column(Order = 0)]
        public int ArticleId { get; set; }
        [Key, Column(Order = 1)]
        public int TagId { get; set; }
    }
}
