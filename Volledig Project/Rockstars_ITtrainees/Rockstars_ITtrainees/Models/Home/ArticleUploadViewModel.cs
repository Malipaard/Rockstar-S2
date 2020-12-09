using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
        public string Tag { get; set; }
        [Required]
        [FileExtensions(Extensions = "jpg,png,gif,jpeg,bmp,svg")]
        public IFormFile HeaderImage { get; set; }
        [Required]
        [FileExtensions(Extensions = "pdf")]
        public IFormFile Content { get; set; }
    }
}
