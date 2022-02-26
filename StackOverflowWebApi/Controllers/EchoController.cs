using System.Threading.Tasks;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using StackOverflow.Common.Services;
using StackOverflowWebApi.Services;

namespace StackOverflowWebApi.Controllers;

[ApiController]
[Route("api/echo")]
public class EchoController : ControllerBase
{

    private readonly IEchoClient _echoClient;

    public EchoController(IEchoClient echoClient)
    {
        _echoClient = echoClient;
    }

    [HttpGet("test")]
    public async Task<IActionResult> Echo(string message)
    {
        var result = await _echoClient.Echo(message);
        return Ok(result);
    }
}