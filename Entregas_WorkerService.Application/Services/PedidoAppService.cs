using Entregas_WorkerService.Application.Commands;
using Entregas_WorkerService.Application.Interfaces;
using Entregas_WorkerService.Domain.Entities;
using Entregas_WorkerService.Domain.Entities.Enums;
using Entregas_WorkerService.Domain.Interfaces.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entregas_WorkerService.Application.Services
{
    public class PedidoAppService : IPedidoAppService
    {
        private readonly IPedidoDomainService? _pedidoDomainService;
        public PedidoAppService(IPedidoDomainService pedidoDomainService)
        {
            _pedidoDomainService = pedidoDomainService;
        }
        public async Task UpdateStatus(PedidoSaiuPraEntregaCommand command)
        {
            try
            {
               await _pedidoDomainService.ProcessarEntregaAsync(command.PedidoId, StatusPedido.SaiuParaEntrega);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
