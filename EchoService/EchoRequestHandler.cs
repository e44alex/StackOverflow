using MassTransit;
using StackOverflow.Common.Models;

namespace EchoService;

public class EchoRequestHandler : IConsumer<EchoMessage>
{
    public Task Consume(ConsumeContext<EchoMessage> context)
    {
        return context.Message.MessageText switch {
            "Marco" => context.RespondAsync(new EchoMessage{MessageText = "Polo"}),
            _ => context.RespondAsync(new EchoMessage { MessageText = "IDK..." })
        };
    }
}