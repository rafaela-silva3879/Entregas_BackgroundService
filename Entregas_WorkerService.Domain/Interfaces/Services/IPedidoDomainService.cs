using Entregas_WorkerService.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entregas_WorkerService.Domain.Interfaces.Services
{
    public interface IPedidoDomainService : IAsyncDisposable
    {
        Task ProcessarEntregaAsync(string pedidoId, StatusPedido statusRecebidoInicialmente);
    }
}
