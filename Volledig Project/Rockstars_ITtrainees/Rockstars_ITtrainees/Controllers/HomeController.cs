using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ITtrainees.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Rockstars_ITtrainees.Models;
using ITtrainees.Logic;

namespace Rockstars_ITtrainees.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult OutEnv()
        {
            return View();
        }

        public IActionResult CTest()
        {
            return View();
        }
        public IActionResult ArticleUpload()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult ArticleUpload(Article article)
        {
            article.ArticleId = ITtrainees.Logic.ArticleProcessor.ArticleStorage.Count;
            ITtrainees.Logic.ArticleProcessor.Save(article);
            return View();
        }
    }
}
