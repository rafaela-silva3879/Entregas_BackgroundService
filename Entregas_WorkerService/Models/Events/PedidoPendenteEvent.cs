using Entregas_WorkerService.Service.Models.Payloads;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Entregas_WorkerService.Service.Models.Events
{
    public class PedidoPendenteEvent
    {
        [JsonProperty("DetalhesPedido")]
        public string DetalhesPedidoString { get; set; }

        public Guid EventId { get; set; } // pra rastrear o evento
        public DateTime? CreatedAt { get; set; } // pra rastrear o evento

        [JsonIgnore]
        public DetalhesPedido DetalhesPedido
        {
            get
            {
                return JsonConvert.DeserializeObject<DetalhesPedido>(DetalhesPedidoString);
            }
        }
    }


}

