using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DevDay.Quiz.Models
{
    [Table("Sessions")]
    public class Session
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Speaker { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
        [Range(0, 2)]
        public int Track { get; set; }
        public DateTime Date { get; set; }
    }
}