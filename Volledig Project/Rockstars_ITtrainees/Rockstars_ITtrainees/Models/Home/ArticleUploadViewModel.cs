using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ITtrainees.Models;

namespace ITtrainees.MVC.Models.Home
{
    public class ArticleUploadViewModel
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string Summary { get; set; }
        [Required]
        public List<ArticleTagModel> Tags { get; set; }
        [Required]
        public IFormFile HeaderImage { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public List<Question> Questions { get; set; }
    }
}
