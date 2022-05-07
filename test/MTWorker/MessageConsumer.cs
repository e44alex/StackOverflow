﻿using System;
using System.Threading.Tasks;
using MassTransit;

namespace MTWorker
{
    public class MessageConsumer : IConsumer<Message>
    {
        public Task Consume(ConsumeContext<Message> context)
        {
            Console.WriteLine(context.Message.MessageText);

            return context.RespondAsync(new Message { MessageText = "response" });
        }
    }

    public class Message
    {
        public string MessageText { get; set; }
    }
}