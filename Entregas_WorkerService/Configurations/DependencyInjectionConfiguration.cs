using Entregas_WorkerService.Application.Interfaces;
using Entregas_WorkerService.Application.Services;
using Entregas_WorkerService.Domain.Interfaces.Repositories;
using Entregas_WorkerService.Domain.Interfaces.Services;
using Entregas_WorkerService.Domain.Services;
using Entregas_WorkerService.Infra.Data.Contexts;
using Entregas_WorkerService.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Subscriber.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entregas_WorkerService.Service.Configurations
{
    public class DependencyInjectionConfiguration
    {
        public static void AddDependencyInjection
(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MessageBrokerSettings>(
                configuration.GetSection("MessageBrokerSettings"));

            services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("Conexao")));

            services.AddTransient<IPedidoAppService, PedidoAppService>();
            services.AddTransient<IPedidoDomainService, PedidoDomainService>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}
