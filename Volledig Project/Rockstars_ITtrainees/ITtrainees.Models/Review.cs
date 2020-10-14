using System;
using System.Collections.Generic;
using System.Text;

namespace ITtrainees.Models
{
    public class Review
    {
        public int ReviewId { get; set; }
        public int Rating { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
    }
}
