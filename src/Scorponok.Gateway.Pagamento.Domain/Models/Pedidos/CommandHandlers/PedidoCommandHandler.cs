using Scorponok.Gateway.Pagamento.Domain.CommandHandlers;
using Scorponok.Gateway.Pagamento.Domain.Core.Bus;
using Scorponok.Gateway.Pagamento.Domain.Core.Events;
using Scorponok.Gateway.Pagamento.Domain.Core.Notifications;
using Scorponok.Gateway.Pagamento.Domain.Interfaces;
using Scorponok.Gateway.Pagamento.Domain.Models.Pedidos.Commands;
using Scorponok.Gateway.Pagamento.Domain.Models.Pedidos.Events;
using Scorponok.Gateway.Pagamento.Domain.Models.Pedidos.IRespository;
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
        , IHandler<CancelarTransacaoEventCommand>
        , IHandler<CapturarTransacaoEventCommand>
    {

        private readonly IPedidoRepository _pedidoRepository;
        private readonly IUnitOfWork _uow;
        private readonly IBus _bus;
        private readonly IDomainNotificationHandler<DomainNotification> _notification;

        public PedidoCommandHandler(IPedidoRepository pedidoRepository, IUnitOfWork uow, IBus bus, IDomainNotificationHandler<DomainNotification> notification)
            : base(uow, bus, notification)
        {
            _pedidoRepository = pedidoRepository;
            _bus = bus;
            _notification = notification;
        }

        public void Handle(AutorizarEventCommand message)
        {
            var pedido = Pedido.Factory.Create(message.IdentificadorPedido);

            //Realiza as validações de negocio....
            //falta definir os erros encontrados 
            //this.NotifyErrors(pedido.ValidationResult);

            _pedidoRepository.Add(pedido);

            if (this.Commit())
            {
                //Processo concluido....
                _bus.RaiseEvent(new TransacaoAutorizadaEvent(pedido.Id));
            }
        }

        public void Handle(CancelarTransacaoEventCommand message)
        {
            throw new NotImplementedException();
        }

        public void Handle(CapturarTransacaoEventCommand message)
        {
            throw new NotImplementedException();
        }
    }
}
