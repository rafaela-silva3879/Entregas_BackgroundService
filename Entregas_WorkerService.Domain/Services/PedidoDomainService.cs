using Entregas_WorkerService.Domain.Entities;
using Entregas_WorkerService.Domain.Entities.Enums;
using Entregas_WorkerService.Domain.Interfaces.Repositories;
using Entregas_WorkerService.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entregas_WorkerService.Domain.Services
{
    public class PedidoDomainService : IPedidoDomainService
    {
        private readonly IUnitOfWork? _unitOfWork;
        public PedidoDomainService(IUnitOfWork? unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Pedido> GetByIdAsync(string id)
        {
            try
            {
                var p = await _unitOfWork.PedidoRepository.GetByIdAsync(id);
                return p;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private async Task UpdateStatusPedidoAsync(string id, StatusPedido status)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();
                var p = await _unitOfWork.PedidoRepository.GetByIdAsync(id);

                if (p == null)
                    throw new Exception($"Pedido com ID '{id}' não encontrado no banco.");

                p.Status = status;
                await _unitOfWork.PedidoRepository.UpdateAsync(p);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }
        }

        public async Task ProcessarEntregaAsync(string pedidoId, StatusPedido statusRecebidoInicialmente)
        {
            if (statusRecebidoInicialmente == StatusPedido.SaiuParaEntrega)
            {
                // Atualiza o status para "Saiu para entrega"
                await UpdateStatusPedidoAsync(pedidoId, StatusPedido.SaiuParaEntrega);

                // Simula o tempo de entrega (3 segundos)
                await Task.Delay(3000);

                // Define aleatoriamente se foi entregue com sucesso ou falhou
                var random = new Random();
                var sucesso = random.Next(0, 2) == 0; // 0 ou 1

                var novoStatus = sucesso
                    ? StatusPedido.EntregueComSucesso
                    : StatusPedido.FalhaNaEntrega;

                // Atualiza o status com o resultado final
                await UpdateStatusPedidoAsync(pedidoId, novoStatus);
            }
        }

        public async ValueTask DisposeAsync()
        {
            if (_unitOfWork != null)
                await _unitOfWork.DisposeAsync();
        }
    }
}
