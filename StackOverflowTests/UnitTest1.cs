using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using StackOverflow.Controllers;
using StackOverflowWebApi.Controllers;
using StackOverflowWebApi.Models;


namespace StackOverflowTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [Test]
        public void Test_QuestionsController_GetQuestions_ReturnsListOfQuestions()
        {
            var service = new Mock<AppDbContext>();
            service.Setup( context => context.Questions.ToList())
                .Returns(() => new List<Question>());

            QuestionsController controller = new QuestionsController(service.Object);

            var result = controller.GetQuestions();

            Assert.IsNotEmpty(result.Result.Value);
        }
    }
}