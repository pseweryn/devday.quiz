using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DevDay.Quiz.Models
{
    [Table("Answers")]
    public class Answer
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public virtual Question Question { get; set; }
        [Display(Name = "Order")]
        public int SortOrder { get; set; }
        [Display(Name = "Answer Text")]
        public string Text { get; set; }
        public bool Correct { get; set; }
    }
}