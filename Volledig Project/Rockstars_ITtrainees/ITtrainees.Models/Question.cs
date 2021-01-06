using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ITtrainees.Models
{
    public class Question
    {
        public int QuestionId { get; set; }

        [ForeignKey("ArticleId")]
        public int ArticleId { get; set; }
        public string QuestionText { get; set; }
        public string Answer1 { get; set; }
        public string Answer2 { get; set; }
        public string CorrectAnswer { get; set; }

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
