using Scorponok.Gateway.Pagamento.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scorponok.Gateway.Pagamento.Domain.Models.Pedidos.Events
{
    public class TransacaoAutorizadaEvent : BasePedidoEvent
    {
        public TransacaoAutorizadaEvent(Guid id)
        {
            this.AggregateId = id;
        }
    }
}
