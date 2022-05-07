using System;
using System.Threading;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.Extensions.Hosting;

namespace MTWorker
{
    public class Worker: BackgroundService
    {
        readonly IBus _bus;

        public Worker(IBus bus)
        {
            _bus = bus;
        }

        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var _requestClient = _bus.CreateRequestClient<Message>();
            while (!stoppingToken.IsCancellationRequested)
            {
                var message = await _requestClient.GetResponse<Message>(new Message { MessageText = $"The time is {DateTimeOffset.Now}" }, stoppingToken);
                Console.WriteLine(message.Message.MessageText);
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}