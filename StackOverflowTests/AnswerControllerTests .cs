using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using StackOverflow.Common.Models;
using StackOverflowWebApi.Controllers;
using StackOverflowWebApi.Models;
using System;
using System.Linq;

namespace StackOverflowTests;

public class AnswersControllerTests
{
    private AppDbContext _context;

    [SetUp]
    public void Setup()
    {
        var builder = new DbContextOptionsBuilder<AppDbContext>();
        builder.UseInMemoryDatabase("testDB1");
        _context = new AppDbContext(builder.Options);

        _context.Add(new User { Email = "e44alex@gmail.com", PasswordHash = AuthController.HashPassword("admin") });
        _context.Add(new Question());
        _context.Add(new Answer());
        _context.Add(new AnswerLiker());
        _context.SaveChangesAsync();
    }

    [Test]
    public void Test_AnswersController_GetAnswers_ReturnsListOfAnswers()
    {
        var controller = new AnswersController(_context);

        var result = controller.GetAnswers();

        Assert.IsNotEmpty(result.Result.Value);
    }

    [Test]
    public void Test_AnswersController_GetAnswerById_ReturnsQuestion()
    {
        var controller = new AnswersController(_context);

        var result = controller.GetAnswer(_context.Answers.Select(x => x.Id).FirstOrDefault());
        Assert.IsInstanceOf<Answer>(result.Result.Value);
    }

    [Test]
    public void Test_AnswersController_PostAnswer()
    {
        var controller = new AnswersController(_context);

        var result = controller.PostAnswer(new Answer
        {
            Id = Guid.NewGuid(),
            Question = _context.Questions.FirstOrDefault(),
            Creator = _context.Users.FirstOrDefault(),
            Body = "test"
        });

        Assert.IsInstanceOf<ActionResult<Answer>>(result.Result);
    }

    [Test]
    public void Test_AnswersController_PutAnswer()
    {
        var controller = new AnswersController(_context);

        var answer = _context.Answers.FirstOrDefault();

        var result = controller.PutAnswer(answer.Id, answer);

        var changedQuestion = _context.Answers.Find(answer.Id);

        //because of EF entity refs 
        Assert.AreEqual(answer, changedQuestion);
    }


    [Test]
    public void Test_AnswersController_DeleteQuestion()
    {
        var controller = new AnswersController(_context);

        var questionForDelete = _context.Answers.FirstOrDefault();

        var result = controller.DeleteAnswer(questionForDelete.Id).Result.Value;

        Assert.AreEqual(questionForDelete, result);
    }
}