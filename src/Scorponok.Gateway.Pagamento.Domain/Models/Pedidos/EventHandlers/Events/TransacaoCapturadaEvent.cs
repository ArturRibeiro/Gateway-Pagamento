using Scorponok.Gateway.Pagamento.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scorponok.Gateway.Pagamento.Domain.Models.Pedidos.EventHandlers.Events
{
    public class TransacaoCapturadaEvent : BasePedidoEvent
    {
        public TransacaoCapturadaEvent(Guid id)
        {
            this.AggregateId = id;
        }
    }
}
