using Scorponok.Gateway.Pagamento.Domain.Core.CommandHandlers;
using Scorponok.Gateway.Pagamento.Domain.Core.Events;
using Scorponok.Gateway.Pagamento.Domain.Models.Pedidos.Commands;
using Scorponok.Gateway.Pagamento.Domain.Models.Pedidos.Respository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scorponok.Gateway.Pagamento.Domain.Models.Pedidos.CommandHandlers
{
    /// <summary>
    /// Manipulador de comando....
    /// </summary>
    public class PedidoCommandHandler : CommandHandler
        , IHandler<AutorizarEventCommand>
        , IHandler<CancelarEventCommand>
        , IHandler<CapturarEventCommand>
    {

        private readonly IPedidoRepository _pedidoRepository;

        public PedidoCommandHandler(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        public void Handle(AutorizarEventCommand message)
        {
            var pedido = Pedido.Factory.Create(message.IdentificadorPedido);

            //Realiza as validações de negocio....
            //falta definir os erros encontrados 
            //this.NotifyErrors(pedido.ValidationResult);

            _pedidoRepository.Add(pedido);
        }

        public void Handle(CancelarEventCommand message)
        {
            throw new NotImplementedException();
        }

        public void Handle(CapturarEventCommand message)
        {
            throw new NotImplementedException();
        }
    }
}
