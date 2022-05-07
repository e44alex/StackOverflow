using System;
using System.Threading.Tasks;
using MassTransit;

namespace MTDocker
{
    public class MessageConsumer : IConsumer<Message>
    {
        public Task Consume(ConsumeContext<Message> context)
        {
            Console.WriteLine(context.Message.MessageText);
            return Task.CompletedTask;
        }
    }

    public class Message
    {
        public string MessageText { get; set; }
    }
}