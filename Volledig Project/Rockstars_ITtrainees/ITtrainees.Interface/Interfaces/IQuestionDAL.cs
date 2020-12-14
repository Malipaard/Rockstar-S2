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
    }
}
