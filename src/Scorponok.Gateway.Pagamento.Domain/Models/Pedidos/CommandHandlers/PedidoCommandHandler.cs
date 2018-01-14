using Scorponok.Gateway.Pagamento.Domain.CommandHandlers;
using Scorponok.Gateway.Pagamento.Domain.Core.Bus;
using Scorponok.Gateway.Pagamento.Domain.Core.Notifications;
using Scorponok.Gateway.Pagamento.Domain.Interfaces;
using Scorponok.Gateway.Pagamento.Domain.Models.Lojas.IRespository;
using Scorponok.Gateway.Pagamento.Domain.Models.Pedidos.CommandHandlers.Commands;
using Scorponok.Gateway.Pagamento.Domain.Models.Pedidos.EventHandlers.Events;
using Scorponok.Gateway.Pagamento.Domain.Models.Pedidos.ICommandHandler;
using Scorponok.Gateway.Pagamento.Domain.Models.Pedidos.IRespository;
using Scorponok.Gateway.Pagamento.Domain.Models.Pedidos.IService;
using Scorponok.Gateway.Pagamento.Infra.Cross.Cutting.Utility;
using System;

namespace Scorponok.Gateway.Pagamento.Domain.Models.Pedidos.CommandHandlers
{
    /// <summary>
    /// Manipulador de comando....
    /// </summary>
    public class PedidoCommandHandler : CommandHandler, IPedidoCommandHandler
    {
        #region Atributos
        private readonly IUnitOfWork _uow;
        private readonly IBus _bus;
        private readonly ILojaService _lojaService;
        private readonly IDomainNotificationHandler<DomainNotification> _notification;
        #endregion

        public PedidoCommandHandler(IUnitOfWork uow, IBus bus, ILojaService lojaService, IDomainNotificationHandler<DomainNotification> notification)
            : base(uow, bus, notification)
        {
            _bus = bus;
            _lojaService = lojaService;
            _notification = notification;
        }

        public void Handle(AutorizarPedidoEventCommand message)
        {
            Verify.ThrowIf(message == null, () => new ArgumentNullException("message"));

            var pedido = _lojaService.Save(message.LojaToken
                , message.IdentificadorPedido
                , message.ValorCentavos
                , message.NumeroCartaoCredito
                , message.Portador);



            ////Realiza as validações de negocio....
            ////falta definir os erros encontrados 
            ////this.NotifyErrors(pedido.ValidationResult);

            if (this.Commit())
            {
                //Processo concluido....
                _bus.RaiseEvent(new PedidoAutorizadoEvent(pedido.Id));
            }
        }

        public void Handle(CancelarPedidoEventCommand message)
        {
            //var pedido = _pedidoRepository.GetById(message.PedidoToken);

            //Chama o serviço de pedido para continuar processando o fluxo

            //pedido.CancelarTransacoes();

            //_pedidoRepository.Add(pedido);

            //if (this.Commit())
            //{
            //    //Processo concluido....
            //    _bus.RaiseEvent(new PedidoCanceladoEvent(pedido.Id));
            //}
        }

        public void Handle(CapturarPedidoEventCommand message)
        {
            throw new NotImplementedException();
        }
    }
}
