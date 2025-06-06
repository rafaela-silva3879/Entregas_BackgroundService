using Subscriber.Settings;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Entregas_WorkerService.Service;
using Entregas_WorkerService.Service.Configurations;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        DependencyInjectionConfiguration.AddDependencyInjection(services, context.Configuration);

        services.AddHostedService<PedidosConsumer>();
    })
    .Build();

host.Run();
