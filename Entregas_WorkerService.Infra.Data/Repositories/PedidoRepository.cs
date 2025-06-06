using Entregas_WorkerService.Domain.Entities;
using Entregas_WorkerService.Domain.Interfaces.Repositories;
using Entregas_WorkerService.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entregas_WorkerService.Infra.Data.Repositories
{
    public class PedidoRepository
    : BaseRepository<Pedido, string>, IPedidoRepository //PedidoRepository does not implement interface member IBaseRepository<Pedido, string>.GetByIdAsync(string)
    {
        private readonly DataContext? _dataContext;
        public PedidoRepository(DataContext? dataContext)
        : base(dataContext)
        {
            _dataContext = dataContext;
        }


    }
}
