using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StackOverflowWebApi.Models;
using StackOverflowWebApi.Services;

namespace ApiFrontEnd.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IApiClient _apiClient;

        public List<Question> Questions { get; set; }

        public bool Authenticated { get; set; }

        public MyPageViewModel PageViewModel { get; set; }

        public class MyPageViewModel(int count, int pageNumber, int pageSize)
        {
            private int PageNumber { get; } = pageNumber;
            private int TotalPages { get; } = (int)Math.Ceiling(count / (double)pageSize);
        }


        public IndexModel(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task OnGet(string? searchText = "")
        {
            Questions = await _apiClient.GetQuestionsAsync();
            Questions = Questions.OrderByDescending(x => x.LastActivity).ToList();
            if (!String.IsNullOrEmpty(searchText))
            {
                Questions = Questions.Where(x => x.Topic.Contains(searchText)).ToList();
            }
        }
    }
}