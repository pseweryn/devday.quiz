using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevDay.Quiz.Models;

namespace DevDay.Quiz.Controllers
{
    public class QuestionsController : Controller
    {
        private QuizContext db = new QuizContext();

        //
        // GET: /Questions/

        public ActionResult Index()
        {
            var questions = db.Questions.Include(q => q.Session);
            return View(questions.OrderBy(q => q.SortOrder).ToList());
        }

        //
        // GET: /Questions/Create

        public ActionResult Create()
        {
            ViewBag.SessionId = new SelectList(db.Sessions, "Id", "Text");
            return View();
        }

        //
        // POST: /Questions/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Question question)
        {
            if (ModelState.IsValid)
            {
                db.Questions.Add(question);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SessionId = new SelectList(db.Sessions, "Id", "Text", question.SessionId);
            return View(question);
        }

        //
        // GET: /Questions/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Question question = db.Questions.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            ViewBag.SessionId = new SelectList(db.Sessions, "Id", "Text", question.SessionId);
            return View(question);
        }

        //
        // POST: /Questions/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Question question)
        {
            if (ModelState.IsValid)
            {
                db.Entry(question).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SessionId = new SelectList(db.Sessions, "Id", "Text", question.SessionId);
            return View(question);
        }

        //
        // GET: /Questions/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Question question = db.Questions.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        //
        // POST: /Questions/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Question question = db.Questions.Find(id);
            db.Questions.Remove(question);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}