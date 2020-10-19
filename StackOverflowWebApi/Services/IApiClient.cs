using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StackOverflowWebApi.Models;

namespace StackOverflowWebApi.Services
{
    public interface IApiClient
    {
        Task<List<Question>> GetQuestionsAsync();
        Task<Answer> GetAnswerAsync(Guid answerId);
        Task<List<Answer>> GetAnswersByQuestionAsync(Guid questionId);
        Task<bool> AddQuestionAsync(Question question);
        Task<bool> AddAnswerAsync(Answer answer);
        Task<bool> UpdateAnswerAsync(Answer answer);
        Task<bool> UpdateQuestionAsync(Question question);
        Task<User> GetUserData(string username);
    }
}