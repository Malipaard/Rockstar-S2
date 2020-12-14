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
        [HttpGet("{id}/{answer}")]
        public string Validate(int id, string answer) 
        {
            IQuestionDAL questionDal = QuestionFactory.GetQuestionDAL();
            Question question = questionDal.GetQuestion(id);

            // id = 2
            // answer = 'correct'
            if (answer == question.CorrectAnswer)
            {
                return "Lekker gewerkt";
            }
            else
            {
                return "fucking dom";
            }
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
    }
}
