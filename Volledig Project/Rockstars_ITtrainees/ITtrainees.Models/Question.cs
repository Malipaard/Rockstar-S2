using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ITtrainees.Models
{
    public class Question
    {
        public int QuestionId { get; private set; }

        [ForeignKey("ArticleId")]
        public int ArticleId { get; private set; }
        public string QuestionText { get; private set; }
        public string Answer1 { get; private set; }
        public string Answer2 { get; private set; }
        public string CorrectAnswer { get; private set; }

        public bool IsAnswerCorrect(string givenAnswer)
        {
            if (givenAnswer == this.CorrectAnswer)
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
