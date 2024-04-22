using ConsultServiceState;
using ConsultServiceState.Entities.Interfaces;
using ConsultServiceState.Services.Http;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
        services.AddHttpClient<IConsultServiceState, ConsultState>();
    })
    .Build();

host.Run();
