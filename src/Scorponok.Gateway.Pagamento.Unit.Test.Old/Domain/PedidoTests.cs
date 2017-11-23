using Scorponok.Gateway.Pagamento.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using FluentAssertions;

namespace Scorponok.Gateway.Pagamento.Unit.Test.Domain
{
    public class PedidoTests
    {
        [Theory, InlineData("01234567890", 12574, "P001245878598", "Artur Araújo")]
        public void Modelar_pedido(string codigoPedido, int valorCentavos, string numero, string portador)
        {
            #region Arrange's

            var pedido = Pedido.Factory.Create(codigoPedido);
            pedido.AdicionaFormaPagamentoCartaoCredito(valorCentavos, numero, portador);

            #endregion

            #region Stub's
            #endregion

            #region Act
            #endregion

            #region Assert's

            pedido.Should().NotBeNull();
            pedido.IdentificadorPedido.Should().Be(codigoPedido);
            pedido.FormaPagamento.CartaoCredito.Should().NotBeNull();
            pedido.FormaPagamento.CartaoCredito.Transactions.Should().HaveCount(1);

            var transacao = pedido.FormaPagamento.CartaoCredito.Transactions[0];

            transacao.CartaoCredito.Should().NotBeNull();
            transacao.CartaoCredito.Bandeira.Should().NotBeNull();
            transacao.CartaoCredito.Numero.Should().NotBeNull();
            transacao.CartaoCredito.AnoExpiracao.Should().BeGreaterThan(2017);
            transacao.CartaoCredito.Portador.Should().NotBeNull();
            transacao.CartaoCredito.Cvv.Should().NotBeNull();

            #endregion

        }
    }
}
