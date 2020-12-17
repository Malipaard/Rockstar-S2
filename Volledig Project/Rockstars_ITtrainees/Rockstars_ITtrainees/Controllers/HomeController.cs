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
            if (!User.Identity.IsAuthenticated) return RedirectToAction("Login","Accounts");
            return View();
        }

        public IActionResult ArticleDelete()
        {
            if (!User.IsInRole("Admin")) return RedirectToAction("Login","Accounts");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
        [HttpPost]
        public async Task<IActionResult> ArticleUpload(ArticleUploadViewModel model, string correctAnswer1, string correctAnswer2)
        {
            if (!User.Identity.IsAuthenticated) return RedirectToAction("Login", "Accounts");
            //if (ModelState.IsValid != true)
            //{
            //    return View(model);
            //}
            APIHelper.InitializeClient();
            Question question1 = model.Questions[0];
            Question question2 = model.Questions[1];
            
            if (correctAnswer1 == "Answer1")
            {
                question1.CorrectAnswer = question1.Answer1;
            }
            else if (correctAnswer1 == "Answer2")
            {
                question1.CorrectAnswer = question1.Answer2;
            }

            if (correctAnswer2 == "Answer1")
            {
                question2.CorrectAnswer = question2.Answer1;
            }
            else if (correctAnswer2 == "Answer2")
            {
                question2.CorrectAnswer = question2.Answer2;
            }

            await ArticleOperations.Create(model);
            
            question1.ArticleId = await ArticleOperations.GetArticleId(model.Author);
            question2.ArticleId = await ArticleOperations.GetArticleId(model.Author);
            
            QuestionOperations.Create(question1);
            QuestionOperations.Create(question2);
            ModelState.Clear();
            return View();
        }

        [HttpPost]
        public IActionResult ArticleDelete(Article article)
        {
            if (!User.IsInRole("Admin")) return RedirectToAction("Login", "Accounts");
            APIHelper.InitializeClient();
            ArticleOperations.Delete(article.ArticleId);
            return View();
        }
    }
}
