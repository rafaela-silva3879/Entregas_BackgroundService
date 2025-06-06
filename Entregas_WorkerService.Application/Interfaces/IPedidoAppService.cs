using Entregas_WorkerService.Application.Commands;
using Entregas_WorkerService.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entregas_WorkerService.Application.Interfaces
{
    public interface IPedidoAppService
    {
        Task UpdateStatus(PedidoSaiuPraEntregaCommand command);
    }
}
