using Scorponok.Gateway.Pagamento.Domain.Core.Events;
using Scorponok.Gateway.Pagamento.Domain.Models.Pedidos.CommandHandlers.Commands;

namespace Scorponok.Gateway.Pagamento.Domain.Models.Pedidos.ICommandHandler
{
    public interface IPedidoCommandHandler :
         IHandler<AutorizarPedidoEventCommand>
        , IHandler<CancelarPedidoEventCommand>
        , IHandler<CapturarPedidoEventCommand>
    {

    }
}
