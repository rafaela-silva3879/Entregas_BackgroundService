using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entregas_WorkerService.Service.Models.Payloads
{
    public class PedidoPayloadModel
    {
        [JsonProperty("DetalhesPedido")]
        public string DetalhesPedidoString { get; set; }
        public Guid EventId { get; set; }
        public DateTime? CreatedAt { get; set; }
        [JsonIgnore]
        public DetalhesPedido DetalhesPedido
        {
            get
            {
                return JsonConvert.DeserializeObject
            <DetalhesPedido>(DetalhesPedidoString);
            }
        }
    }
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

