using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Server.IIS.Core;
using Microsoft.IdentityModel.JsonWebTokens;
using StackOverflowWebApi.Models;

namespace StackOverflowWebApi.Services
{
    public class ApiClient : IApiClient
    {
        private readonly HttpClient _httpClient;

        public ApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Question>> GetQuestionsAsync()
        {
            var response = await _httpClient.GetAsync($"/api/Questions");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<List<Question>>();
        }

        public async Task<Question> GetQuestionAsync(Guid id)
        {
            var response = await _httpClient.GetAsync($"/api/Questions/{id}");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<Question>();
        }

        public async Task<Answer> GetAnswerAsync(Guid answerId)
        {
            var response = await _httpClient.GetAsync($"/api/Answers/{answerId}");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<Answer>();
        }

        public async Task<List<Answer>> GetAnswersByQuestionAsync(Guid questionId)
        {
            var response = await _httpClient.GetAsync($"/api/Answers/byQuestion/{questionId}");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<List<Answer>>();
        }

        public async Task<bool> AddQuestionAsync(Question question)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/Questions", question);

            if (response.StatusCode == HttpStatusCode.Conflict)
            {
                return false;
            }

            response.EnsureSuccessStatusCode();

            return true;
        }

        public async Task<bool> AddAnswerAsync(Answer answer)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/Answers/", answer);

            if (response.StatusCode == HttpStatusCode.Conflict)
            {
                return false;
            }

            response.EnsureSuccessStatusCode();

            return true;
        }

        public async Task<bool> UpdateAnswerAsync(Answer answer)
        {
            var response = await _httpClient.PutAsJsonAsync($"/api/Answers/{answer.Id}", answer);

            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return false;
            }

            response.EnsureSuccessStatusCode();

            return true;
        }

        public async Task<bool> UpdateQuestionAsync(Question question)
        {
            var response = await _httpClient.PutAsJsonAsync($"/api/Questions/{question.Id}", question);

            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return false;
            }

            response.EnsureSuccessStatusCode();

            return true;
        }

        public async Task<User> GetUserDataAsync(string username)
        {
            var response = await _httpClient.GetAsync($"/api/Users/byName/{username}");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<User>();
        }

        public async Task<Guid> GetUserIdAsync(string username)
        {
            var response = await _httpClient.GetAsync($"/api/Users/getId/{username}");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<Guid>();
        }

        public async Task<bool> Authenticate(string username, string password)
        {
            try
            {
                var response = await _httpClient.GetAsync($"/token?username={username}&password={password}");

                response.EnsureSuccessStatusCode();

                var headers = response.Headers;
                string token = "";
                if (headers.TryGetValues("token", out IEnumerable<string> headerValues))
                {
                    token = headerValues.FirstOrDefault();
                }

                _httpClient.DefaultRequestHeaders.Add("Authorization", token);

                var response2 = await _httpClient.GetAsync($"/checkLogin?userName={username}");
                

                response2.EnsureSuccessStatusCode();

            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> UnAuthenticate(string inputUsername)
        {
            var response = await _httpClient.GetAsync($"/logOut?username={inputUsername}");

            response.EnsureSuccessStatusCode();

            return true;
        }

        public async Task<bool> UpdateUserAsync(User user)
        {
            var response = await _httpClient.PutAsJsonAsync($"/api/Users/{user.Id}", user);

            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return false;
            }

            response.EnsureSuccessStatusCode();

            return true;
        }

        public async Task<bool> AddUserAsync(User user)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/Users", user);

            if (response.StatusCode == HttpStatusCode.Conflict)
            {
                return false;
            }

            response.EnsureSuccessStatusCode();

            return true;
        }

        public async Task<bool> LikeAnswerAsync(Guid answerId,string username)
        {
            var response = await _httpClient.GetAsync($"/like?answerId={answerId}&username={username}");

            if (response.StatusCode == HttpStatusCode.Conflict)
            {
                return false;
            }

            response.EnsureSuccessStatusCode();

            return true;
        }
    }
}