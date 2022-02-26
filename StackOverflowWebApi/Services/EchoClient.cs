using System.Threading.Tasks;
using MassTransit;
using StackOverflow.Common.Models;
using StackOverflow.Common.Services;

namespace StackOverflowWebApi.Services;

class EchoClient : IEchoClient
{
    private readonly IBus _bus;

    public EchoClient(IBus bus)
    {
        _bus = bus;
    }

    public async Task<string> Echo(string message)
    {
        var _responseClient = _bus.CreateClientFactory().CreateRequestClient<EchoMessage>();
        var response = await _responseClient.GetResponse<EchoMessage>(new EchoMessage{MessageText = message});

        return response.Message.MessageText;
    }
}