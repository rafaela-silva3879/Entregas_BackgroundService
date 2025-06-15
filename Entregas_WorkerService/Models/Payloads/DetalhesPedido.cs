using System.Collections.Generic;

namespace Entregas_WorkerService.Service.Models.Payloads
{
    public class DetalhesPedido
    {
        public string? PedidoId { get; set; }
        public Destinatario? Destinatario { get; set; }
        public List<ItemPedido>? Itens { get; set; } = new();
    }

    public class Destinatario
    {
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Cep { get; set; }
    }

    public class ItemPedido
    {
        public string Descricao { get; set; }
        public int Quantidade { get; set; }
    }
}

