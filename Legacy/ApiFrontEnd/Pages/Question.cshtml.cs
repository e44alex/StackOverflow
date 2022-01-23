using System;
using System.Threading.Tasks;
using ApiFrontEnd.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StackOverflowWebApi.Models;
using StackOverflowWebApi.Services;

namespace ApiFrontEnd.Pages;

public class QuestionModel : PageModel
{
    private readonly IApiClient _apiClient;

    public QuestionModel(IApiClient apiClient)
    {
        _apiClient = apiClient;
    }

    public Question Question { get; set; }

    public async Task OnGet(Guid id)
    {
        Question = await _apiClient.GetQuestionAsync(id);
    }

    public async Task<RedirectResult> OnPost(Guid questionId, Answer answer)
    {
        answer.Creator = new User
        {
            Id = await _apiClient.GetUserIdAsync(HttpContext.Request.Cookies["user"])
        };

        answer.Id = new Guid();
        answer.Question = await _apiClient.GetQuestionAsync(answer.Question.Id);
        var token = HttpContext.Request.Cookies["token"].Decrypt();

        await _apiClient.AddAnswerAsync(answer, token);

        return Redirect($"/Question?id={answer.Question.Id}");
    }

    public async Task<RedirectResult> OnPostLike(Answer answer, Question question)
    {
        await _apiClient.LikeAnswerAsync(answer.Id, HttpContext.Request.Cookies["user"],
            HttpContext.Request.Cookies["token"].Decrypt());

        return Redirect($"/Question?id={question.Id}");
    }
}