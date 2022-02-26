using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StackOverflow.Common.Services;
using StackOverflow.DTO;

namespace StackOverflowWebApi.Services;

public class ApiClient : IApiClient
{
    #region QueueChannels

    protected const string AuthenticationChannel = "Authentication";
    protected const string UsersChannel = "Users";
    protected const string QuestionsChannel = "QuestionAnswers";
    protected const string EchoChannel = "Echo";

    #endregion

    public ApiClient()
    {
    }

    public Task<List<QuestionDTO.Response>> GetQuestionsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<QuestionDTO.Response> GetQuestionAsync(Guid questionId)
    {
        throw new NotImplementedException();
    }

    public Task<AnswerDTO.Response> GetAnswerAsync(Guid answerId)
    {
        throw new NotImplementedException();
    }

    public Task<List<AnswerDTO.Response>> GetAnswersByQuestionAsync(Guid questionId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> AddQuestionAsync(QuestionDTO.Request question)
    {
        throw new NotImplementedException();
    }

    public Task<bool> AddQuestionAsync()
    {
        throw new NotImplementedException();
    }

    public Task<bool> AddAnswerAsync(AnswerDTO.Request answer)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAnswerAsync(AnswerDTO.Request answer)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateQuestionAsync(QuestionDTO.Request question)
    {
        throw new NotImplementedException();
    }

    public Task<UserDTO.Response> GetUserDataAsync(string username)
    {
        throw new NotImplementedException();
    }

    public Task<Guid> GetUserIdAsync(string username)
    {
        throw new NotImplementedException();
    }

    public Task<string> Authenticate(string username, string password)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UnAuthenticate(string inputUsername)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateUserAsync(UserDTO.Request user)
    {
        throw new NotImplementedException();
    }

    public Task<bool> AddUserAsync(UserDTO.Request user)
    {
        throw new NotImplementedException();
    }

    public Task<bool> LikeAnswerAsync(Guid answerId, string username)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAnswer(Guid answerId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteQuestion(Guid id)
    {
        throw new NotImplementedException();
    }

    #region Legacy

    //public async Task<List<QuestionDTO.Response>> GetQuestionsAsync()
    //{
    //    var response = await _httpClient.GetAsync("/api/Questions");

    //    response.EnsureSuccessStatusCode();

    //    return await response.Content.ReadAsAsync<List<Question>>();
    //}

    //public async Task<Question> GetQuestionAsync(Guid questionId)
    //{
    //    var response = await _httpClient.GetAsync($"/api/Questions/{questionId}");

    //    response.EnsureSuccessStatusCode();

    //    return await response.Content.ReadAsAsync<Question>();
    //}

    //public async Task<List<Answer>> GetAnswersByQuestionAsync(Guid questionId)
    //{
    //    var response = await _httpClient.GetAsync($"/api/Answers/byQuestion/{questionId}");

    //    response.EnsureSuccessStatusCode();

    //    return await response.Content.ReadAsAsync<List<Answer>>();
    //}

    //public async Task<bool> AddQuestionAsync(Question question, string token)
    //{
    //    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
    //    var response = await _httpClient.PostAsJsonAsync("/api/Questions", question);

    //    if (response.StatusCode == HttpStatusCode.Conflict) return false;

    //    response.EnsureSuccessStatusCode();

    //    return true;
    //}

    //public async Task<bool> UpdateQuestionAsync(Question question)
    //{
    //    var response = await _httpClient.PutAsJsonAsync($"/api/Questions/{question.Id}", question);

    //    if (response.StatusCode == HttpStatusCode.NotFound) return false;

    //    response.EnsureSuccessStatusCode();

    //    return true;
    //}

    #region Answer

    //public async Task<Answer> GetAnswerAsync(Guid answerId)
    //{
    //    var response = await _httpClient.GetAsync($"/api/Answers/{answerId}");

    //    response.EnsureSuccessStatusCode();

    //    return await response.Content.ReadAsAsync<Answer>();
    //}

    //public async Task<bool> AddAnswerAsync(Answer answer, string token)
    //{
    //    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
    //    var response = await _httpClient.PostAsJsonAsync("/api/Answers/", answer);

    //    if (response.StatusCode == HttpStatusCode.Conflict) return false;

    //    response.EnsureSuccessStatusCode();

    //    return true;
    //}

    //public async Task<bool> UpdateAnswerAsync(Answer answer)
    //{
    //    var response = await _httpClient.PutAsJsonAsync($"/api/Answers/{answer.AnswerId}", answer);

    //    if (response.StatusCode == HttpStatusCode.NotFound) return false;

    //    response.EnsureSuccessStatusCode();

    //    return true;
    //}

    //public async Task<bool> LikeAnswerAsync(Guid answerId, string username, string token)
    //{
    //    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
    //    var response = await _httpClient.GetAsync($"/like?answerId={answerId}&username={username}");

    //    if (response.StatusCode == HttpStatusCode.Conflict) return false;

    //    response.EnsureSuccessStatusCode();

    //    return true;
    //}

    //#endregion

    //#region User

    //public async Task<User> GetUserDataAsync(string username)
    //{
    //    var response = await _httpClient.GetAsync($"/api/Users/byName/{username}");

    //    response.EnsureSuccessStatusCode();

    //    return await response.Content.ReadAsAsync<User>();
    //}

    //public async Task<Guid> GetUserIdAsync(string username)
    //{
    //    var response = await _httpClient.GetAsync($"/api/Users/getId/{username}");

    //    response.EnsureSuccessStatusCode();

    //    return await response.Content.ReadAsAsync<Guid>();
    //}


    //public async Task<bool> UpdateUserAsync(User user, string token)
    //{
    //    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
    //    var response = await _httpClient.PutAsJsonAsync($"/api/Users/{user.UserId}", user);

    //    if (response.StatusCode == HttpStatusCode.NotFound) return false;

    //    response.EnsureSuccessStatusCode();

    //    return true;
    //}

    //public async Task<bool> AddUserAsync(User user)
    //{
    //    var response = await _httpClient.PostAsJsonAsync("/api/Users", user);

    //    if (response.StatusCode == HttpStatusCode.Forbidden) return false;

    //    response.EnsureSuccessStatusCode();

    //    return true;
    //}

    //private async Task<int?> SetUserRatingAsync(string userName)
    //{

    //}

    #endregion

    #region Authenticate

    //public async Task<string> Authenticate(string username, string password)
    //{
    //    try
    //    {
    //        var response = await _httpClient.GetAsync($"/token?username={username}&password={password}");

    //        response.EnsureSuccessStatusCode();

    //        var headers = response.Headers;
    //        var token = "";
    //        if (headers.TryGetValues("token", out var headerValues)) token = headerValues.FirstOrDefault();

    //        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
    //        var cookieContainer = new CookieContainer();

    //        cookieContainer.Add(new Uri("https://localhost:44328/"), new Cookie("token", token));

    //        var response2 = await _httpClient.GetAsync($"/checkLogin?userName={username}");


    //        response2.EnsureSuccessStatusCode();

    //        return token;
    //    }
    //    catch (Exception e)
    //    {
    //        return null;
    //    }
    //}

    //public async Task<bool> UnAuthenticate(string inputUsername)
    //{
    //    var response = await _httpClient.GetAsync($"/logOut?username={inputUsername}");

    //    response.EnsureSuccessStatusCode();

    //    return true;
    //}

    #endregion

    #endregion
}