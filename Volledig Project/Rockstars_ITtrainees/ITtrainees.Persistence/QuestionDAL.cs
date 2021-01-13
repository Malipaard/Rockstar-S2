using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ITtrainees.Models;
using ITtrainees.Interface.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ITtrainees.DataAcces
{
    public class QuestionDAL : IQuestionDAL
    {
        public void Create(Question question)
        {
            using (var context = new ArticlesContext())
            {
                context.Questions.Add(question);
                context.SaveChanges();
            }
        }

        public List<Question> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Question> GetArticleQuestions(int articleId)
        {
            using (var context = new ArticlesContext())
            {
                var questions = context.Questions.Where(q => q.ArticleId == articleId).ToList();
                return questions;
            }
        }

        public Question GetQuestion(int id)
        {
            using (var context = new ArticlesContext())
            {
                var question = context.Questions.Single(q => q.QuestionId == id);
                return question;
            }
        }

        public void Update(Question question)
        {
            using (var context = new ArticlesContext())
            {
                var dbQuestion = context.Questions.Single(q => q.QuestionId == question.QuestionId);

                dbQuestion.Answer1 = question.Answer1;
                dbQuestion.Answer2 = question.Answer2;
                dbQuestion.ArticleId = question.ArticleId;
                dbQuestion.CorrectAnswer = question.CorrectAnswer;
                dbQuestion.QuestionId = question.QuestionId;
                dbQuestion.QuestionText = question.QuestionText;

                context.SaveChanges();
            }
        }


        public void QuestionAnswered(string username, int questionID)
        {
            AnsweredQuestion answeredQuestion = new AnsweredQuestion(username, questionID);
            using (var context = new ArticlesContext())
            {

                using (var transaction = context.Database.BeginTransaction())
                {
                    context.AnsweredQuestions.Add(answeredQuestion);
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.AnsweredQuestions ON;");
                    context.SaveChanges();
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.AnsweredQuestions OFF");
                    transaction.Commit();
                }
            }
        }
        public bool QuestionIsAlreadyAnswered(string username, int questionID)
        {
            AnsweredQuestion answeredQuestion = new AnsweredQuestion(username, questionID);
            using (var context = new ArticlesContext())
            {
                if (context.AnsweredQuestions.Any(a => a.Username == answeredQuestion.Username && a.QuestionID == answeredQuestion.QuestionID))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

    }
}
