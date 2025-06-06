using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscriber.Models.Payloads.Enums
{
    public enum StatusPedido
    {
        Pendente = 0,
        SaiuParaEntrega = 1,
        EntregueComSucesso = 2,
        FalhaNaEntrega = 3
    }
}
