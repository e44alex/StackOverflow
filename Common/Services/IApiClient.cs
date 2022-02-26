using StackOverflow.DTO;

namespace StackOverflow.Common.Services;

public interface IApiClient
{
    Task<List<QuestionDTO.Response>> GetQuestionsAsync();
    Task<QuestionDTO.Response> GetQuestionAsync(Guid questionId);
    Task<AnswerDTO.Response> GetAnswerAsync(Guid answerId);
    Task<List<AnswerDTO.Response>> GetAnswersByQuestionAsync(Guid questionId);
    Task<bool> AddQuestionAsync(QuestionDTO.Request question);
    Task<bool> AddAnswerAsync(AnswerDTO.Request answer);
    Task<bool> UpdateAnswerAsync(AnswerDTO.Request answer);
    Task<bool> UpdateQuestionAsync(QuestionDTO.Request question);
    Task<UserDTO.Response> GetUserDataAsync(string username);
    Task<Guid> GetUserIdAsync(string username);
    Task<string> Authenticate(string username, string password);

    Task<bool> UnAuthenticate(string inputUsername);
    Task<bool> UpdateUserAsync(UserDTO.Request user);
    Task<bool> AddUserAsync(UserDTO.Request user);

    Task<bool> LikeAnswerAsync(Guid answerId, string username);
    Task<bool> DeleteAnswer(Guid answerId);
    Task<bool> DeleteQuestion(Guid id);
}