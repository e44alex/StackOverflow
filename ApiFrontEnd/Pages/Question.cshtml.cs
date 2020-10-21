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


            await _apiClient.AddAnswerAsync(answer);

            return Redirect($"/Question?id={answer.Question.Id}");
        }

        public async Task<RedirectResult> OnPostLike(Answer answer)
        {
            var currentUser = await _apiClient.GetUserDataAsync("e44alex");

            if (!answer.Users.Any(u => u.User.Equals(User)))
            {
                answer.Users.Add(new AnswerLiker()
                {
                    Id = Guid.NewGuid(),
                    Answer = answer,
                    User = currentUser

                });
            }

            await _apiClient.UpdateAnswerAsync(answer);

            return Redirect($"/Question?id={answer.Question.Id}");
        }
    }
}
