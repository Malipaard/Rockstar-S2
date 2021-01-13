﻿using System;
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
using ITtrainees.DataAcces;
using System.Data;

namespace Rockstars_ITtrainees.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> IndexAsync(string tag)
        {
            IndexViewModel viewModel = new IndexViewModel();
            APIHelper.InitializeClient();
            List<ArticleCard> cardList = await ArticleOperations.GetAllCards();
            cardList.Reverse();
            viewModel.RecentArticles = cardList;
            viewModel.FilteredArticles = cardList;

            try
            {
                if (!String.IsNullOrEmpty(tag))
                {
                    viewModel.FilteredArticles = cardList.Where(article => article.Tag.Equals(tag)).ToList();
                }
                return View(viewModel);
            }

            //Add messagebox to user that no articles are found!
            catch
            {
                ViewBag.Message = string.Format("No articles with specified tag found!");
                return View(viewModel);
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }
        

        public async Task<IActionResult> Leaderboard()
        {
            List<Account> accountList = await AccountOperations.GetAll();
            List<Account> sortedList = accountList.OrderByDescending(o => o.Points).ToList();
            
            return View(sortedList);
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
            ArticleUploadViewModel model = new ArticleUploadViewModel();
            if (!User.Identity.IsAuthenticated) return RedirectToAction("Login", "Accounts");
            model.Author = User.Identity.Name;
            return View(model);
        }

        public IActionResult login()
        {
            if (!User.IsInRole("Admin")) return RedirectToAction("Login", "Accounts");
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
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult ArticleDelete(Article article)
        {
            if (!User.IsInRole("Admin")) return RedirectToAction("Login", "Accounts");
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

        public async Task<IActionResult> QuestionsUpdate(int articleId)
        {
            List<Question> Questions = await QuestionOperations.Get(articleId);
            QuestionsUpdateModel questions = new QuestionsUpdateModel
            {
                QuestionId1 = Questions[0].QuestionId,
                QuestionId2 = Questions[1].QuestionId,
                ArticleId = Questions[0].ArticleId,
                QuestionText1 = Questions[0].QuestionText,
                q1Answer1 = Questions[0].Answer1,
                q1Answer2 = Questions[0].Answer2,
                q1CorrectAnswer = Questions[0].CorrectAnswer,
                QuestionText2 = Questions[1].QuestionText,
                q2Answer1 = Questions[1].Answer1,
                q2Answer2 = Questions[1].Answer2,
                q2CorrectAnswer = Questions[1].CorrectAnswer
            };

            return View(questions);
        }

        public IActionResult UpdateQuestion(QuestionsUpdateModel questions)
        {
            if (questions.q1CorrectAnswer == "Answer1")
            {
                questions.q1CorrectAnswer = questions.q1Answer1;
            }
            else if (questions.q1CorrectAnswer == "Answer2")
            {
                questions.q1CorrectAnswer = questions.q1Answer2;
            }

            if (questions.q2CorrectAnswer == "Answer1")
            {
                questions.q2CorrectAnswer = questions.q2Answer1;
            }
            else if (questions.q2CorrectAnswer == "Answer2")
            {
                questions.q2CorrectAnswer = questions.q2Answer2;
            }

            Question question1 = new Question
            {
                QuestionId = questions.QuestionId1,
                ArticleId = questions.ArticleId,
                QuestionText = questions.QuestionText1,
                Answer1 = questions.q1Answer1,
                Answer2 = questions.q1Answer2,
                CorrectAnswer = questions.q1CorrectAnswer
            };
            QuestionOperations.Update(question1);
            Question question2 = new Question
            {
                QuestionId = questions.QuestionId2,
                ArticleId = questions.ArticleId,
                QuestionText = questions.QuestionText2,
                Answer1 = questions.q2Answer1,
                Answer2 = questions.q2Answer2,
                CorrectAnswer = questions.q2CorrectAnswer
            };
            QuestionOperations.Update(question2);
            return RedirectToAction("UpdateArticle", new { id = questions.ArticleId });
        }
    }
}
