using Scorponok.Gateway.Pagamento.Domain.CommandHandlers;
using Scorponok.Gateway.Pagamento.Domain.Core.Bus;
using Scorponok.Gateway.Pagamento.Domain.Core.Events;
using Scorponok.Gateway.Pagamento.Domain.Core.Notifications;
using Scorponok.Gateway.Pagamento.Domain.Interfaces;
using Scorponok.Gateway.Pagamento.Domain.Models.Pedidos.CommandHandlers.Commands;
using Scorponok.Gateway.Pagamento.Domain.Models.Pedidos.EventHandlers.Events;
using Scorponok.Gateway.Pagamento.Domain.Models.Pedidos.IRespository;
using Scorponok.Gateway.Pagamento.Domain.Models.Pedidos.IService;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scorponok.Gateway.Pagamento.Domain.Models.Pedidos.CommandHandlers
{
    /// <summary>
    /// Manipulador de comando....
    /// </summary>
    public class PedidoCommandHandler : CommandHandler
        , IHandler<AutorizarPedidoEventCommand>
        , IHandler<CancelarPedidoEventCommand>
        , IHandler<CapturarPedidoEventCommand>
    {

        private readonly IPedidoRepository _pedidoRepository;
        private readonly IUnitOfWork _uow;
        private readonly IBus _bus;
        //private readonly IPedidoService _pedidoService;
        private readonly IDomainNotificationHandler<DomainNotification> _notification;

        public PedidoCommandHandler(IPedidoRepository pedidoRepository, IUnitOfWork uow, IBus bus, IPedidoService pedidoService, IDomainNotificationHandler<DomainNotification> notification)
            : base(uow, bus, notification)
        {
            _pedidoRepository = pedidoRepository;
            _bus = bus;
            //_pedidoService = pedidoService;
            _notification = notification;
        }

        public void Handle(AutorizarPedidoEventCommand message)
        {
            var pedido = Pedido.Factory.Create(message.IdentificadorPedido);

            //Realiza as validações de negocio....
            //falta definir os erros encontrados 
            //this.NotifyErrors(pedido.ValidationResult);

            _pedidoRepository.Add(pedido);

            if (this.Commit())
            {
                //Processo concluido....
                _bus.RaiseEvent(new PedidoAutorizadoEvent(pedido.Id));
            }
        }

        public void Handle(CancelarPedidoEventCommand message)
        {
            var pedido = _pedidoRepository.GetById(message.PedidoToken);

            //Chama o serviço de pedido para continuar processando o fluxo

            pedido.CancelarTransacoes();

            _pedidoRepository.Add(pedido);

            if (this.Commit())
            {
                //Processo concluido....
                _bus.RaiseEvent(new PedidoCanceladoEvent(pedido.Id));
            }

        }

        public void Handle(CapturarPedidoEventCommand message)
        {
            throw new NotImplementedException();
        }
    }
}
