using System;
using System.Collections.Generic;
using System.Text;

namespace Scorponok.Gateway.Pagamento.Domain.Models.Pedidos.CommandHandlers.Commands
{
    public class CancelarPedidoEventCommand : BaseEventCommand
    {

        public Guid PedidoToken { get; private set; }

        public int ValorEmCentavos { get; private set; }

        public CancelarPedidoEventCommand(Guid pedidoToken, int valorEmCentavos)
        {
            this.PedidoToken = pedidoToken;
            this.ValorEmCentavos = valorEmCentavos;
        }
    }
}
