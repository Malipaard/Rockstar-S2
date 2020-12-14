using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ITtrainees.Models;
using ITtrainees.Interface.Interfaces;

namespace ITtrainees.DataAcces
{
    public class QuestionDAL : IQuestionDAL
    {
        public List<Question> GetAll()
        {
            throw new NotImplementedException();
        }

        public Question GetQuestion(int id)
        {
            using (var context = new ArticlesContext())
            {
                var question = context.Questions.Single(q => q.QuestionId == id);
                return question;
            }
        }
    }
}
