using StackOverflow.DTO;

namespace StackOverflow.Common.Services;

public interface IApiClient
{
    Task<List<QuestionDTO.Response>> GetQuestionsAsync();
    Task<QuestionDTO.Response?> GetQuestionAsync(Guid questionId);
    Task<GetAnswerDTO.Response> GetAnswerAsync(Guid answerId);
    Task<List<GetAnswerDTO.Response>> GetAnswersByQuestionAsync(Guid questionId);
    Task<bool> AddQuestionAsync(PostQuestionDTO.Request question);
    Task<bool> AddAnswerAsync(PostAnswerDTO.Request answer);
    Task<bool> UpdateAnswerAsync(PutAnswerDTO.Request answer);
    Task<bool> UpdateQuestionAsync(PutQuestionDTO.Request question);
    Task<PostUserDTO.Response> GetUserDataAsync(string username);
    Task<string> Authenticate(string username, string password);

    Task<bool> UnAuthenticate(string username);
    Task<bool> UpdateUserAsync(PostUserDTO.Request user);
    Task<bool> AddUserAsync(PostUserDTO.Request user);

    Task<bool> LikeAnswerAsync(Guid answerId, string username);
    Task<bool> DeleteAnswer(Guid answerId);
    Task<bool> DeleteQuestion(Guid id);
}