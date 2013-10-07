using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DevDay.Quiz.Models
{
    [Table("Questions")]
    public class Question
    {
        public int Id { get; set; }
        [Display(Name = "Question Text")]
        public string Text { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
        [Display(Name = "Order")]
        public int SortOrder { get; set; }
        public int SessionId { get; set; }
        public virtual Session Session { get; set; }
    }
}