using System;
using System.Threading.Tasks;
using ApiFrontEnd.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StackOverflowWebApi.Models;
using StackOverflowWebApi.Services;

namespace ApiFrontEnd.Pages;

public class QuestionCreateModel : PageModel
{
    private readonly IApiClient _apiClient;

    public QuestionCreateModel(IApiClient apiClient)
    {
        _apiClient = apiClient;
    }

    public Question Question { get; set; }

    public async Task<RedirectResult> OnPostAsync(Question question)
    {
        var user = new User
        {
            Id = await _apiClient.GetUserIdAsync(HttpContext.Request.Cookies["user"])
        };

        question.Creator = user;
        question.Id = Guid.NewGuid();

        var token = HttpContext.Request.Cookies["token"].Decrypt();

        await _apiClient.AddQuestionAsync(question, token);

        return Redirect($"/Question?id={question.Id}");
    }
}