using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITtrainees.MVC.APITools;
using ITtrainees.MVC.Models.Home;
using Microsoft.AspNetCore.Mvc;

namespace ITtrainees.MVC.Controllers
{
    public class QuestionController : Controller
    {
        public async Task<IActionResult> AnswerQuestion(ArticleViewViewModel model)
        {
            Console.WriteLine(model.ToString());
            APIHelper.InitializeClient();
            string userName = User.Identity.Name;
            List<string> responses = new List<string>();
            if (model.GivenAnswers == null)
            {
                TempData["EmptyAnswer"] = true;
                return RedirectToAction("ArticleView", "Home", new { id = model.ArticleId });
            }
            foreach (var answer in model.GivenAnswers)
            {
                if (String.IsNullOrEmpty(answer))
                {
                    TempData["EmptyAnswer"] = true;
                    return RedirectToAction("ArticleView", "Home", new { id = model.ArticleId });
                }
            }
            for (int i = 0; i < model.Questions.Count; i++)
            {
                string response = await QuestionOperations.Validate(model.Questions[i].QuestionId, model.GivenAnswers[i], userName);
                responses.Add(response);
            }
            TempData["Response"] = responses;
            return RedirectToAction("ArticleView", "Home", new { id = model.ArticleId });
        }
    }
}
