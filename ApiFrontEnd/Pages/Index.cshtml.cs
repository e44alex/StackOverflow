using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StackOverflowWebApi.Models;
using StackOverflowWebApi.Services;

namespace ApiFrontEnd
{
    public class IndexModel : PageModel
    {
        protected readonly IApiClient _apiClient;

        public List<Question> Questions { get; set; }

        public bool Authenticated { get; set; }


        public IndexModel(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task OnGet()
        {
            Questions = await _apiClient.GetQuestionsAsync();
        }
    }
}
