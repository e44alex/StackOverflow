using System;
using System.Collections.Generic;
using StackOverflow.Models;

namespace StackOverflow.Controllers;

public class IndexViewModel
{
    public IEnumerable<Question> Questions { get; set; }
    public PageViewModel VierwModel { get; set; }
}

public class PageViewModel
{
    public PageViewModel(int count, int pageNumber, int pageSize)
    {
        PageNumber = pageNumber;
        TotalPages = (int)Math.Ceiling(count / (double)pageSize);
    }

    public int PageNumber { get; }
    public int TotalPages { get; }

    public bool HasPreviousPage => PageNumber > 1;

    public bool HasNextPage => PageNumber < TotalPages;
}