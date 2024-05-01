using ConsultServiceState;
using ConsultServiceState.Entities.Interfaces;
using ConsultServiceState.Services.Http;
using ConsultServiceState.Services.RabbitMQ;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
        services.AddHttpClient<IConsultServiceState, ConsultState>();
        services.AddSingleton<IRabbitMQ, CreateLogRabbitMQ>();
    })
    .Build();

host.Run();
