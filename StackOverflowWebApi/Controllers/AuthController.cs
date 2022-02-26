using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StackOverflowWebApi.Models;
using System.Threading.Tasks;
using StackOverflowWebApi.Helpers;

namespace StackOverflowWebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly AppDbContext _context;

    public AuthController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet("/token")]
    public async Task<IActionResult> Token(string username, string password)
    {
        var identity = await AuthenticationHelpers.GetIdentity(username, password);
        if (identity == null) return BadRequest(new { errorText = "Invalid username or password" });

        var token = await AuthenticationHelpers.CreateToken(identity);

        var response = new { access_token = token, username = identity.Name };

        HttpContext.Response.Headers.Append("token", token);

        return Ok(response);
    }

    //[Authorize]
    [HttpGet("/ping")]
    public async Task<IActionResult> Ping()
    {
        return Ok("You are authorized");
    }

    //[Authorize]
    [HttpGet("/logOut")]
    public async Task<IActionResult> LogOut()
    {
        return Ok("You are unauthorized");
    }
}