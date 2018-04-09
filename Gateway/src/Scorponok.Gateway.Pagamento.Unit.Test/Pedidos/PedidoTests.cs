
using FizzWare.NBuilder;
using Scorponok.Gateway.Pagamento.Domain.Models;
using Scorponok.Gateway.Pagamento.Domain.Models.Lojas;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using FluentAssertions;
using Scorponok.Gateway.Pagamento.Domain.Models.Pedidos;

namespace Scorponok.Gateway.Pagamento.Unit.Test.Pedidos
{
    public class PedidoTests
    {
        [Theory, InlineData(10000, "12312312313123123", "Allan de Souza")]
        public void Criar_pedido_com_historico(int valorEmCentavos, string numeoCartaoCredito, string portador)
        {
            Loja loja = Builder<Loja>
                .CreateNew()
                .Build();

            Pedido pedido = Builder<Pedido>
                .CreateNew()
                    .With(x => x.Loja, loja)
                    .Do(x => x.AdicionaFormaPagamentoCartao(valorEmCentavos, numeoCartaoCredito, portador))
                .Build();


            pedido.Should().NotBeNull();
        }
    }
}
