using System;
using System.Collections.Generic;
using System.Text;
using ITtrainees.DataAcces;
using ITtrainees.Interface.Interfaces;


namespace ITtrainees.Factory
{
    public static class QuestionFactory
    {
        public static IQuestionDAL GetQuestionDAL()
        {
            return new QuestionDAL();
        }
    }
}
