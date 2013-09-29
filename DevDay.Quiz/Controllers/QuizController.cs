using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevDay.Quiz.Models;

namespace DevDay.Quiz.Controllers
{
    public class QuizController : Controller
    {
        QuizContext db = new QuizContext();

        public ActionResult Index()
        {
            ViewBag.Message = db.Questions.Any() ? ConfigurationManager.AppSettings["WelcomeMessage"] :"No questions yet. Please come back later";

            return View(db.Questions.ToList());
        }

        public ActionResult Results()
        {
            var participants = from p in db.Participants
                               orderby p.CorrectAnswerCount descending 
                               select p;
           
            return View(participants);
        }

        [HttpPost]
        public JsonResult Finish(QuizDataViewModel data)
        {
            Participant participant = new Participant() {Nick = data.Nickname};
            List<Answer> answers = db.Answers.ToList();

            string[] userAnswers = data.Results.Split(',');
            for (int i = 0; i < userAnswers.Length; i++)
            {
                string userAnswer = userAnswers[i];
                int answerId = Int16.Parse(userAnswer.Substring(userAnswer.IndexOf("-", StringComparison.Ordinal) + 1));
                Answer answer = answers.FirstOrDefault(a => a.Id == answerId);
                if (answer != null && answer.Correct)
                {
                    participant.CorrectAnswerCount++;
                }
            }

            db.Participants.Add(participant);
            db.SaveChanges();
            return Json("Thanks!");
        }
    }
}
