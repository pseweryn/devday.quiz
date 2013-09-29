using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DevDay.Quiz.Models
{
    public class QuizContext : DbContext
    {
        public QuizContext() : base("DefaultConnection")
        {            
        }

        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }

        public DbSet<Participant> Participants { get; set; }
    }
}