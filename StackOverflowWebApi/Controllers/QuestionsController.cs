using Microsoft.AspNetCore.Mvc;
using StackOverflow.Common.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using StackOverflow.Common.Services;
using StackOverflow.DTO;
using Answer = StackOverflowWebApi.Models.Answer;
using Question = StackOverflowWebApi.Models.Question;

namespace StackOverflowWebApi.Controllers;

[Route("api/questions")]
[ApiController]
public class QuestionsController : ControllerBase
{
    private readonly IApiClient _apiClient;
    private readonly IMapper _mapper;

    public QuestionsController(IApiClient apiClient, IMapper mapper)
    {
        _apiClient = apiClient;
        _mapper = mapper;
    }

    // GET: api/Questions
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Question>>> GetQuestions()
    {
        var result = await _apiClient.GetQuestionsAsync();

        return Ok(_mapper.Map<List<Question>>(result));
    }

    // GET: api/Questions/5
    [HttpGet("{id}")]
    public async Task<ActionResult> GetQuestion(Guid id)
    {
        var result = await _apiClient.GetQuestionsAsync();

        return result != null ? Ok(_mapper.Map<Question>(result)) : NotFound();
    }

    // PUT: api/Questions/5
    //[Authorize]
    [HttpPut("{id}")]
    public async Task<IActionResult> PutQuestion(Guid id, Question question)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var request = _mapper.Map<QuestionDTO.Request>(question);
        var result = await _apiClient.UpdateQuestionAsync(request);

        return result switch {
            true => Ok(),
            _ => NotFound()
        };
    }

    // POST: api/Questions
    //[Authorize]
    [HttpPost]
    public async Task<ActionResult<Question>> PostQuestion(Question question)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var request = _mapper.Map<QuestionDTO.Request>(question);
        var result = await _apiClient.AddQuestionAsync(request);

        return result switch
        {
            true => Ok(),
            _ => NotFound()
        };
    }

    // DELETE: api/Questions/5

    //[Authorize]
    [HttpDelete("{id}")]
    public async Task<ActionResult<Question>> DeleteQuestion(Guid id)
    {
        var result = await _apiClient.DeleteQuestion(id);

        return result switch
        {
            true => Ok(),
            _ => NotFound()
        };
    }

    // GET: api/Answers/5
    [HttpGet("{id}/answers")]
    public async Task<IActionResult> GetQuestionAnswers(Guid id)
    {
        var result = await _apiClient.GetAnswersByQuestionAsync(id);

        return Ok(_mapper.Map<List<Answer>>(result));
    }
}