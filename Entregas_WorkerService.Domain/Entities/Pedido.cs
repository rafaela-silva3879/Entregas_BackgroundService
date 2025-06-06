using Entregas_WorkerService.Domain.Entities.Enums;
using Entregas_WorkerService.Domain.Interfaces.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entregas_WorkerService.Domain.Entities
{
    public class Pedido : IExcluivel
    {
        public string PedidoId { get; set; }

        public Guid DestinatarioId { get; set; }

        public StatusPedido Status { get; set; }

        public bool Excluido { get; set; } = false;
    }
}
