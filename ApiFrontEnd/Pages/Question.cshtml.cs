using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StackOverflowWebApi.Models;
using StackOverflowWebApi.Services;

namespace ApiFrontEnd.Pages
{
    public class QuestionModel : PageModel
    {
        private readonly IApiClient _apiClient;

        public Question Question { get; set; }

        public QuestionModel(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task OnGet(Guid id)
        {
            Question = await _apiClient.GetQuestionAsync(id);
        }

        public async Task<RedirectResult> OnPost(Answer answer)
        {
            answer.Creator = new User()
            {
                Id = await _apiClient.GetUserIdAsync("e44alex")
            };
            answer.DateCreated = DateTime.Now;
            answer.Question = await _apiClient.GetQuestionAsync(answer.Id);
            answer.Id = Guid.NewGuid();

            await _apiClient.AddAnswerAsync(answer);

            return Redirect($"/Question?id={answer.Question.Id}");
        }
    }
}
