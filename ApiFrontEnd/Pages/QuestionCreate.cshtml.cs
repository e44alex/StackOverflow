using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using StackOverflowWebApi.Models;
using StackOverflowWebApi.Services;

namespace ApiFrontEnd.Pages
{
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
            /*TODO -- get authorized user's name*/
            var user = new User()
            {
                Id = await _apiClient.GetUserIdAsync("e44alex")
            };
            
            question.Creator = user;
            

            await _apiClient.AddQuestionAsync(question);

            return Redirect($"/Question?id={question.Id}");
        }
    }
}
