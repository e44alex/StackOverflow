using System.Reflection;
using MassTransit;
using Microsoft.Extensions.Hosting;

namespace EchoService;

public class Program
{
    static bool? _isRunningInContainer;

    static bool IsRunningInContainer =>
        _isRunningInContainer ??= bool.TryParse(Environment.GetEnvironmentVariable("DOTNET_RUNNING_IN_CONTAINER"), out var inContainer) && inContainer;

    public static async Task Main(string[] args)
    {
        await CreateHostBuilder(args).Build().RunAsync();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureServices((host, services) =>
            {
                var messagingSection = host.Configuration.GetSection("Messaging");
                var rabbitMqHost = messagingSection["RabbitMqHost"];
                var username = messagingSection["username"];
                var password = messagingSection["password"];

                services.AddMassTransit(x =>
                {
                    x.AddDelayedMessageScheduler();

                    x.SetKebabCaseEndpointNameFormatter();

                    // By default, sagas are in-memory, but should be changed to a durable
                    // saga repository.
                    x.SetInMemorySagaRepositoryProvider();

                    var entryAssembly = Assembly.GetEntryAssembly();

                    x.AddConsumers(entryAssembly);
                    x.AddSagaStateMachines(entryAssembly);
                    x.AddSagas(entryAssembly);
                    x.AddActivities(entryAssembly);

                    x.UsingRabbitMq((context, cfg) =>
                    {
                        if (IsRunningInContainer)
                            cfg.Host("rabbitmq");

                        cfg.UseDelayedMessageScheduler();

                        cfg.ConfigureEndpoints(context);
                    });

                });

                services.AddMassTransitHostedService(true);
            });
}