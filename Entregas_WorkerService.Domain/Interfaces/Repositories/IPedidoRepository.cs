using Entregas_WorkerService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entregas_WorkerService.Domain.Interfaces.Repositories
{
    public interface IPedidoRepository
    : IBaseRepository<Pedido, string>
    {
    }
}
