using System;
using System.Reflection;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using StackOverflowWebApi.Authentication;
using StackOverflowWebApi.Services;
using Swashbuckle.AspNetCore.Filters;
using System.Threading.Tasks;
using MassTransit;
using StackOverflow.Common.Services;

namespace StackOverflowWebApi;

public class Startup
{
    static bool? _isRunningInContainer;

    static bool IsRunningInContainer =>
        _isRunningInContainer ??= bool.TryParse(Environment.GetEnvironmentVariable("DOTNET_RUNNING_IN_CONTAINER"), out var inContainer) && inContainer;


    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers()
            .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            );

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = true;
                options.Events = new JwtBearerEvents
                {
                    OnMessageReceived = context =>
                    {
                        context.Token = context.Request.Cookies["your-cookie"];
                        return Task.CompletedTask;
                    }
                };

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = AuthOptions.ISSUER,
                    ValidateAudience = true,
                    ValidAudience = AuthOptions.AUDIENCE,
                    ValidateLifetime = false,
                    IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                    ValidateIssuerSigningKey = true
                };
            })
            .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
                Configuration.Bind("CookieSettings", options));

        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "StackOverflow API",
                Version = "v1"
            });
            options.AddSecurityDefinition("token", new OpenApiSecurityScheme
            {
                Description = "Standard Authorization header using the Bearer scheme. Example: \"bearer {token}\"",
                In = ParameterLocation.Header,
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey
            });
            options.OperationFilter<SecurityRequirementsOperationFilter>();
        });

        services.AddSingleton<IApiClient, ApiClient>();
        services.AddSingleton<IEchoClient, EchoClient>();

        var messagingSection = Configuration.GetSection("Messaging");
        var rabbitMqHost = messagingSection["RabbitMqHost"];
        var username = messagingSection["username"];
        var password = messagingSection["password"];

        // MESSAGE BROKER
        services.AddMassTransit(configurator =>
        {
            configurator.AddDelayedMessageScheduler();

            configurator.SetKebabCaseEndpointNameFormatter();

            configurator.SetInMemorySagaRepositoryProvider();

            var assembly = Assembly.GetEntryAssembly();

            configurator.AddConsumers(assembly);
            configurator.AddSagaStateMachines(assembly);
            configurator.AddSagas(assembly);
            configurator.AddActivities(assembly);

            configurator.UsingRabbitMq((busRegistrationContext, busFactoryConfigurator) =>
            {
                if (IsRunningInContainer)
                    busFactoryConfigurator.Host("rabbitmq");

                busFactoryConfigurator.UseDelayedMessageScheduler();

                busFactoryConfigurator.ConfigureEndpoints(busRegistrationContext);
            });
        });

        services.AddMassTransitHostedService(true);
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

        app.UseHttpsRedirection();

        app.UseSwagger();

        app.UseSwaggerUI(options =>
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "StackOverflow API v1"));

        app.UseRouting();

        app.UseCors(builder =>
        {
            builder.AllowAnyOrigin();
            builder.AllowAnyHeader();
            builder.AllowAnyMethod();
        });

        app.UseAuthentication();
        app.UseAuthorization();


        app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
    }
}