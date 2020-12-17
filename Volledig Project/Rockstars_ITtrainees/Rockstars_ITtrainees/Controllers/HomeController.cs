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
            List<ArticleCard> cardList = await ArticleOperations.GetAllCards();
            cardList.Reverse();
            return View(cardList);
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
                ArticleId = article.ArticleId,
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
       
        public IActionResult login()
        {
            return View();
        }

        [Route("/article")]
        public async Task<IActionResult> UpdateArticleAsync(int id)
        {
            Article UpdateArticle = await ArticleOperations.Get(id);
            ArticleUpdateModel updateArticle = new ArticleUpdateModel(UpdateArticle);
            return View(updateArticle);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
        [HttpPost]
        public async Task<IActionResult> ArticleUpload(ArticleUploadViewModel model, string correctAnswer1, string correctAnswer2)
        {
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
            return RedirectToAction("Index");
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
            ModelState.Clear();
            return RedirectToAction("Index");
        }

        public IActionResult Update(ArticleUpdateModel article)
        {
            ArticleOperations.Update(article);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeletePageAsync(int id)
        {
            Article article = await ArticleOperations.Get(id);
            return View(article);
        }
    }
}
