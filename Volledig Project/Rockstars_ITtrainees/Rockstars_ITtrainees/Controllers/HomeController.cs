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
            List<Question> questions = await QuestionOperations.Get(id);
            ArticleViewViewModel articleViewViewModel = new ArticleViewViewModel
            {
                Title = article.Title,
                Author = article.Author,
                Summary = article.Summary,
                Tag = article.Tag,
                HeaderImage = article.HeaderImage,
                Content = article.Content,
                Questions = questions
            };

            if (article != null)
            {
                return View(articleViewViewModel);
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

        [HttpPost]
        public IActionResult ArticleDelete(Article article)
        {
            APIHelper.InitializeClient();
            ArticleOperations.Delete(article.ArticleId);
            return View();
        }

        public async Task<IActionResult> AnswerQuestion(ArticleViewViewModel model)
        {
            Console.WriteLine(model.ToString());
            APIHelper.InitializeClient();
            for (int i = 0; i < model.Questions.Count; i++)
            {
                await QuestionOperations.Validate(model.Questions[i].QuestionId, model.GivenAnswers[i]);
            }
            return View("~/Views/Home/Index.cshtml");
        }
    }
}
