using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ITtrainees.Models
{
    public class AnsweredQuestion
    {
        [Key]
        public int QuestionID { get; private set; }
        public string Username { get; private set; }

        public AnsweredQuestion(string username, int questionID)
        {
            Username = username;
            QuestionID = questionID;
        }
    }
}
