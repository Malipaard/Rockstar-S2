using System;
using System.Collections.Generic;
using System.Text;
using ITtrainees.Models;

namespace ITtrainees.Interface.Interfaces
{
    public interface IQuestionDAL
    {
        List<Question> GetAll();
        Question GetQuestion(int id);
        List<Question> GetArticleQuestions(int articleId);
        void Create(Question question);
        void QuestionAnswered(string username, int questionID);
        bool QuestionIsAlreadyAnswered(string username, int questionID);
    }
}
