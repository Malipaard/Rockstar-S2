using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using ITtrainees.Interface.Interfaces;
using ITtrainees.Factory;
using ITtrainees.Models;

namespace ITtrainees.Logic
{
    [Route("api/question")]
    [ApiController]
    public class QuestionAPI : ControllerBase
    {
        [HttpGet("{id}/{answer}/{userName}")]
        public string Validate(int id, string answer, string userName) 
        {
            IQuestionDAL questionDal = QuestionFactory.GetQuestionDAL();
            Question question = questionDal.GetQuestion(id);
            
            if (!questionDal.QuestionIsAlreadyAnswered(userName, id))
            {
                if (answer == question.CorrectAnswer)
                {
                    IAccountDAL accountDAL = AccountFactory.GetAccountDAL();
                    Account account = accountDAL.GetAccount(userName);
                    accountDAL.AddScore(account, 10);
                    questionDal.QuestionAnswered(userName, id);
                    return "Question answered correctly";
                }
                else
                {
                    questionDal.QuestionAnswered(userName, id);
                    return "Question answered incorrectly";
                }
            }
            else
            {
                return "Question already answered";
            }

            // id = 2
            // answer = 'correct'
            
        }

        //api/question/{id}
        [HttpGet("{id:int:min(1)}")]
        public List<Question> Get(int id)
        {
            try
            {
                IQuestionDAL dal = QuestionFactory.GetQuestionDAL();
                var question = dal.GetArticleQuestions(id);
                return question;
            }
            catch
            {
                return null;
            }
        }

        [HttpPost]
        public IActionResult Create(Question question)
        {
            IQuestionDAL dal = QuestionFactory.GetQuestionDAL();
            dal.Create(question);
            return Accepted();
        }

        [HttpPut]
        public IActionResult Update(Question question)
        {
            IQuestionDAL dal = QuestionFactory.GetQuestionDAL();
            dal.Update(question);
            return Accepted();
        }
    }
}
