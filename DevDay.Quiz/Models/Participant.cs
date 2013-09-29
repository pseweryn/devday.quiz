using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DevDay.Quiz.Models
{
    [Table("Participants")]
    public class Participant
    {
        public int Id { get; set; }
        public string Nick { get; set; }
        [Display(Name = "Correct Answers")]
        public int CorrectAnswerCount { get; set; }
    }
}