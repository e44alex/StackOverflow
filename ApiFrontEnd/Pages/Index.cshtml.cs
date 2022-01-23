using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StackOverflowWebApi.Models;
using StackOverflowWebApi.Services;

namespace ApiFrontEnd;

public class IndexModel : PageModel
{
    protected readonly IApiClient _apiClient;


    public IndexModel(IApiClient apiClient)
    {
        _apiClient = apiClient;
    }

    public List<Question> Questions { get; set; }

    public bool Authenticated { get; set; }

    public MyPageViewModel PageViewModel { get; set; }

    public async Task OnGet(string? searchText = "")
    {
        Questions = await _apiClient.GetQuestionsAsync();
        Questions = Questions.OrderByDescending(x => x.LastActivity).ToList();
        if (!string.IsNullOrEmpty(searchText)) Questions = Questions.Where(x => x.Topic.Contains(searchText)).ToList();
    }

    public class MyPageViewModel
    {
        public MyPageViewModel(int count, int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        }

        public int PageNumber { get; }
        public int TotalPages { get; }

        public bool HasPreviousPage => PageNumber > 1;

        public bool HasNextPage => PageNumber < TotalPages;
    }
}