using Microsoft.Extensions.DependencyInjection;
using Scorponok.Gateway.Pagamento.Domain.Enuns;
using Scorponok.Gateway.Pagamento.Domain.Models.Pedidos.CommandHandlers.Commands;
using Scorponok.Gateway.Pagamento.Domain.Models.Pedidos.ICommandHandler;
using Scorponok.Gateway.Pagamento.Infra.Cross.Cutting.Bus;
using System;
using Xunit;

namespace Scorponok.Gateway.Pagamento.Unit.Test.Integration.Commands
{
    public class PedidoCommandHandlerTests : BaseIntegrationTest
    {
        [Theory, InlineData("6C5CC434-6727-4EE6-9DA9-3043CA5BDB79", Operadora.Stone, "AWDR35577", 1000, "012345678965")]
        public void PedidoCommand_sucesso(string lojaToken, Operadora operadora, string identificadorPedido, int valorEmCentavos, string numeroCartaoCredito)
        {
            var pedidoCommandHandler = _serviceProvider.GetService<IPedidoCommandHandler>();

            var eventCommand = new AutorizarPedidoEventCommand(Guid.Parse(lojaToken)
                , operadora
                , identificadorPedido
                , valorEmCentavos
                , numeroCartaoCredito
                , Faker.Name.FullName());

            pedidoCommandHandler.Handle(eventCommand);
        }


    }
}
