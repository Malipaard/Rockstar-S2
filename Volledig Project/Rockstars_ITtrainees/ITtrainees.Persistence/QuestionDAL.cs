﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ITtrainees.Models;
using ITtrainees.Interface.Interfaces;

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
    }
}
