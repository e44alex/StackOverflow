﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StackOverflowWebApi.Models;

namespace StackOverflowWebApi.Services
{
    public interface IApiClient
    {
        Task<List<Question>> GetQuestionsAsync();
        Task<Question> GetQuestionAsync(Guid id);
        Task<Answer> GetAnswerAsync(Guid answerId);
        Task<List<Answer>> GetAnswersByQuestionAsync(Guid questionId);
        Task<bool> AddQuestionAsync(Question question);
        Task<bool> AddAnswerAsync(Answer answer);
        Task<bool> UpdateAnswerAsync(Answer answer);
        Task<bool> UpdateQuestionAsync(Question question);
        Task<User> GetUserDataAsync(string username);
        Task<Guid> GetUserIdAsync(string username);
        Task<bool> Authenticate(string username, string password);

        Task<bool> UnAuthenticate(string inputUsername);
        Task<bool> UpdateUserAsync(User user);
    }
}