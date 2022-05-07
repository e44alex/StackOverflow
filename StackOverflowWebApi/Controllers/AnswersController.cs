using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using StackOverflow.Common.Services;
using StackOverflow.DTO;
using Answer = StackOverflowWebApi.Models.Answer;

namespace StackOverflowWebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AnswersController : ControllerBase
{
    private readonly IApiClient _apiClient;
    private readonly IMapper _mapper;

    public AnswersController(IApiClient apiClient, IMapper mapper)
    {
        _apiClient = apiClient;
        _mapper = mapper;
    }

    // GET: api/Answers/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAnswer(Guid answerId)
    {
        if (ModelState.IsValid)
        {
            var answer = await _apiClient.GetAnswerAsync(answerId);

            return answer != null ? Ok(_mapper.Map<Answer>(answer)) : NotFound();
        }

        return ValidationProblem(ModelState);
    }



    // PUT: api/Answers/5
    //[Authorize]
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAnswer(Guid id, Answer answer)
    {
        if (ModelState.IsValid)
        {
            var request = _mapper.Map<PutAnswerDTO.Request>(answer);
            var result = await _apiClient.UpdateAnswerAsync(request);

            return result switch {
                true => Ok(answer),
                _ => NotFound()
            };
        }

        return ValidationProblem(ModelState);
    }
    
    // POST: api/Answers
    //[Authorize]
    [HttpPost]
    public async Task<ActionResult<Answer>> PostAnswer(Answer answer)
    {
        if (!ModelState.IsValid)
        {
            return ValidationProblem(ModelState);
        }

        var request = _mapper.Map<PostAnswerDTO.Request>(answer);
        var response = await _apiClient.AddAnswerAsync(request);

        return response switch {
            true => Ok(),
            _ => Conflict()
        };
    }

    // DELETE: api/Answers/5
    [HttpDelete("{id}")]
    public async Task<ActionResult<Answer>> DeleteAnswer(Guid answerId)
    {
        var result = await _apiClient.DeleteAnswer(answerId);

        return result switch
        {
            true => Ok(),
            _ => NotFound()
        };
    }

    //[Authorize]
    [HttpGet("/like")]
    public async Task<IActionResult> LikeAnswer(Guid answerId)
    {
        var principal = User.FindFirstValue(ClaimTypes.Name);

        var result = await _apiClient.LikeAnswerAsync(answerId, principal);

        return result switch
        {
            true => Ok(),
            _ => NotFound()
        };
    }
}