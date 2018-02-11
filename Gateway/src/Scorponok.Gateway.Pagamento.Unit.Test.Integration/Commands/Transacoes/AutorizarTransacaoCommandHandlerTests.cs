using FizzWare.NBuilder;
using Scorponok.Gateway.Pagamento.Domain.Models.Transacoes;
using Scorponok.Gateway.Pagamento.Domain.Models.Transacoes.CommandHandlers.Commands;
using Scorponok.Gateway.Pagamento.Domain.Models.Transacoes.ICommandHandler;
using Xunit;
using Microsoft.Extensions.DependencyInjection;

namespace Scorponok.Gateway.Pagamento.Unit.Test.Integration.Commands.Transacoes
{
    public class AutorizarTransacaoCommandHandlerTests : BaseIntegrationTest
    {
        [Theory]
        [InlineData("6C5CC434-6727-4EE6-9DA9-3043CA5BDB79", "AWDR35577", 1000, "012345678965")]
        public void Autorizar_com_sucesso(string lojaToken, string identificadorPedido, int valorEmCentavos, string numeroCartaoCredito)
        {
            //var command = _serviceProvider.GetService<ITransacaoCommandHandler>();

            //var transacao = Builder<Transacao>.CreateNew().Build();

            //var argument = new AutorizarTransacaoEventCommand(transacao);

            //command.Handle(argument);
        }
    }
}
