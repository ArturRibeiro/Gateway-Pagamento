using Scorponok.Gateway.Pagamento.Domain.Core.Events;
using Scorponok.Gateway.Pagamento.Domain.Models.Pedidos.EventHandlers.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scorponok.Gateway.Pagamento.Domain.Models.Pedidos.EventHandlers
{
    public class PedidoEventHandler :
        IHandler<PedidoAutorizadoEvent>,
        IHandler<PedidoCapturadaEvent>,
        IHandler<PedidoCanceladoEvent>
    {
        public void Handle(PedidoAutorizadoEvent message)
        {
            //throw new NotImplementedException();
        }

        public void Handle(PedidoCanceladoEvent message)
        {
            //throw new NotImplementedException();
        }

        public void Handle(PedidoCapturadaEvent message)
        {
            //throw new NotImplementedException();
        }
    }
}
