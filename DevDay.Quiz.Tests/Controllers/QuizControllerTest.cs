using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DevDay.Quiz;
using DevDay.Quiz.Controllers;

namespace DevDay.Quiz.Tests.Controllers
{
    [TestClass]
    public class QuizControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            QuizController controller = new QuizController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.AreEqual("No questions yet. Please come back later", result.ViewBag.Message);
        }

        [TestMethod]
        public void Results()
        {
            // Arrange
            QuizController controller = new QuizController();

            // Act
            ViewResult result = controller.Results() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

    }
}
