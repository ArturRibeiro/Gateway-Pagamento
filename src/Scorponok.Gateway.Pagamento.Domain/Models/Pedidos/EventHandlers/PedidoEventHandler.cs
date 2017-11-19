using Scorponok.Gateway.Pagamento.Domain.Core.Events;
using Scorponok.Gateway.Pagamento.Domain.Models.Pedidos.EventHandlers.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scorponok.Gateway.Pagamento.Domain.Models.Pedidos.EventHandlers
{
    public class PedidoEventHandler :
        IHandler<TransacaoAutorizadaEvent>,
        IHandler<TransacaoCapturadaEvent>,
        IHandler<TransacaoCanceladaEvent>
    {
        public void Handle(TransacaoAutorizadaEvent message)
        {
            throw new NotImplementedException();
        }

        public void Handle(TransacaoCanceladaEvent message)
        {
            throw new NotImplementedException();
        }

        public void Handle(TransacaoCapturadaEvent message)
        {
            throw new NotImplementedException();
        }
    }
}
