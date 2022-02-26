using Microsoft.AspNetCore.Mvc;
using StackOverflow.Common.Models;
using System.Threading.Tasks;
using AutoMapper;
using StackOverflow.Common.Services;
using StackOverflow.DTO;
using User = StackOverflowWebApi.Models.User;

namespace StackOverflowWebApi.Controllers;

[Route("api/users")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IApiClient _apiClient;
    private readonly IMapper _mapper;

    public UsersController(IApiClient apiClient, IMapper mapper)
    {
        _apiClient = apiClient;
        _mapper = mapper;
    }


    // GET: api/Users/5
    [HttpGet("{userName}")]
    public async Task<ActionResult> GetUser(string userName)
    {
        var result = await _apiClient.GetUserDataAsync(userName);

        return result != null ? Ok(_mapper.Map<User>(result)) : NotFound();
    }

    // PUT: api/Users/5
    //[Authorize]
    [HttpPut("{id}")]
    public async Task<IActionResult> PutUser(int id, User user)
    {
        var request = _mapper.Map<UserDTO.Request>(user);
        var result = await _apiClient.UpdateUserAsync(request);

        return result switch {
            true => Ok(),
            _ => NotFound()
        };
    }

    // POST: api/Users
    [HttpPost]
    public async Task<ActionResult<User>> PostUser(User user)
    {
        var request = _mapper.Map<UserDTO.Request>(user);
        var result = await _apiClient.AddUserAsync(request);

        return result switch
        {
            true => Ok(),
            _ => NotFound()
        };
    }

}