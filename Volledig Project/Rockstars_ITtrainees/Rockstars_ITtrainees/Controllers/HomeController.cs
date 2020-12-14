using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ITtrainees.Models;
using ITtrainees.MVC.APITools;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Rockstars_ITtrainees.Models;
using ITtrainees.Logic;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Rockstars_ITtrainees.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> IndexAsync()
        {
            APIHelper.InitializeClient();
            List<Article> articleList = await ArticleOperations.GetAll();
            return View(articleList);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult OutEnv()
        {
            return View();
        }

        [Authorize]
        public IActionResult ArticleUpload()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult ArticleDelete()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Authorize]
        [HttpPost]
        public IActionResult ArticleUpload(Article article)
        {
            APIHelper.InitializeClient();
            ArticleOperations.Create(article);
            ModelState.Clear();
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult ArticleDelete(Article article)
        {
            ArticleOperations.Delete(article.ArticleId);
            return View();
        }

       
    }
}
