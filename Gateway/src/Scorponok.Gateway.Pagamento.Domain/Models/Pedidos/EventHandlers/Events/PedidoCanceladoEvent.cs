using Scorponok.Gateway.Pagamento.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scorponok.Gateway.Pagamento.Domain.Models.Pedidos.EventHandlers.Events
{
    public class PedidoCanceladoEvent : BasePedidoEvent
    {
        public PedidoCanceladoEvent(Guid id)
        {
            this.AggregateId = id;
        }
    }
}
