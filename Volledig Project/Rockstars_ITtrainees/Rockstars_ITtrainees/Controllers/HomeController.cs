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
using ITtrainees.MVC.Models.Home;

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

        public async Task<IActionResult> ArticleView(int id)
        {
            Article article = await ArticleOperations.Get(id);
            if (article != null)
            {
                return View(article);
            }
            return RedirectToAction("Index");
        }

        public IActionResult ArticleUpload()
        {
            return View();
        }

        public IActionResult ArticleDelete()
        {
            return View();
        }
        public IActionResult login()
        {
            return View();
        }

        [Route("/article")]
        public async Task<IActionResult> UpdateArticleAsync(Article article)
        {            
            Article UpdateArticle = await ArticleOperations.Get(article.ArticleId);
            ArticleUpdateModel updateArticle = new ArticleUpdateModel(UpdateArticle);
            return View(updateArticle);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult ArticleUpload(ArticleUploadViewModel model)
        {
            //if (ModelState.IsValid != true)
            //{
            //    return View(model);
            //}
            APIHelper.InitializeClient();
            ArticleOperations.Create(model);
            ModelState.Clear();
            return View();
        }

        //[HttpPost]
        //public IActionResult UpdateArticle(Article article)
        //{
        //    APIHelper.InitializeClient();
        //    ArticleOperations.Update(article);
        //    return View();
        //}

        [HttpPost]
        public IActionResult ArticleDelete(Article article)
        {
            APIHelper.InitializeClient();
            ArticleOperations.Delete(article.ArticleId);

            return RedirectToAction("Index");
        }

        public IActionResult Update(ArticleUpdateModel article)
        {
            Console.WriteLine(article.Content);
            ArticleOperations.Update(article);

            return RedirectToAction("Index");
        }
    }
}
