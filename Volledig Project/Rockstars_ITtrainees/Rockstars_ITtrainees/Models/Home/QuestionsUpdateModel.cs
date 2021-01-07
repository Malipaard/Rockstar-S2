using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ITtrainees.MVC.Models.Home
{
    public class QuestionsUpdateModel
    {
        [Required]
        public int QuestionId1 { get; set; }
        [Required]
        public int QuestionId2 { get; set; }
        [Required]
        [ForeignKey("ArticleId")]
        public int ArticleId { get; set; }
        [Required]
        public string QuestionText1 { get; set; }
        [Required]
        public string q1Answer1 { get; set; }
        [Required]
        public string q1Answer2 { get; set; }
        [Required]
        public string q1CorrectAnswer { get; set; }
        [Required]
        public string QuestionText2 { get; set; }
        [Required]
        public string q2Answer1 { get; set; }
        [Required]
        public string q2Answer2 { get; set; }
        [Required]
        public string q2CorrectAnswer { get; set; }
    }
}
