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
            for (int i = 0; i < model.Questions.Count; i++)
            {
                await QuestionOperations.Validate(model.Questions[i].QuestionId, model.GivenAnswers[i], userName);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
