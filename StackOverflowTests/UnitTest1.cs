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
        private AppDbContext _context;

        [SetUp]
        public void Setup()
        {
            var builder = new DbContextOptionsBuilder<AppDbContext>();
            builder.UseInMemoryDatabase("testDB1");
            _context = new AppDbContext(builder.Options);

            _context.Add(new User());
            _context.Add(new Question());
            _context.Add(new Answer());
            _context.Add(new AnswerLiker());
            _context.SaveChangesAsync();
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [Test]
        public async Task Test_QuestionsController_GetQuestions_ReturnsListOfQuestions()
        {

            QuestionsController controller = new QuestionsController(_context);

            var result = await controller.GetQuestions();

            Assert.IsNotEmpty(result.Value);
        }



        [Test]
        public async Task Test_UsersController_GetUsers_ReturnsListOfUsers()
        {

            UsersController controller = new UsersController(_context);

            var result = await controller.GetUsers();

            Assert.IsNotEmpty(result.Value);
        }

        [Test]
        public async Task Test_AnswersController_Get_ReturnsList()
        {

            AnswersController controller = new AnswersController(_context);

            var result = await controller.GetAnswers();

            Assert.IsNotEmpty(result.Value);
        }


    }
}