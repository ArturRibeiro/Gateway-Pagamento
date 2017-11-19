using Scorponok.Gateway.Pagamento.Domain.Core.Core.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Scorponok.Gateway.Pagamento.Domain.Models
{
    public class Pedido : Entity
    {

        public Pedido()
        {

        }

        private Pedido(string identificadorPedido)
        {
            this.IdentificadorPedido = identificadorPedido;
        }

        #region Propriedades
        /// <summary>
        ///     Identificador do pedido na sua base
        /// </summary>
        public string IdentificadorPedido { get; private set; }

        public FormaPagamento FormaPagamento { get; private set; }
        #endregion

        public void AdicionaFormaPagamentoCartaoCredito(int valorEmCentavos, string numeoCartaoCredito, string portador)
        {
            if (this.FormaPagamento == null) this.FormaPagamento = new FormaPagamento();

            var transacao = Transaction.Factory.Create(valorEmCentavos, numeoCartaoCredito, portador);

            this.FormaPagamento.CartaoCredito.AdicionaTransacao(transacao);
        }

        public void AdicionaFormaPagamentoBoleto(Transaction transacao)
        {
            if (this.FormaPagamento == null) this.FormaPagamento = new FormaPagamento();

            throw new NotImplementedException("AdicionaFormaPagamentoBoleto");
        }
        
        public void AdicionaFormaPagamentoDebitoOnline(Transaction transacao)
        {
            if (this.FormaPagamento == null) this.FormaPagamento = new FormaPagamento();

            throw new NotImplementedException("AdicionaFormaPagamentoDebitoOnline");
        }
        
        public void AdicionaFormaPagamentoPayPal(Transaction transacao)
        {
            if (this.FormaPagamento == null) this.FormaPagamento = new FormaPagamento();

            throw new NotImplementedException("AdicionaFormaPagamentoPayPal");
        }

        internal void CancelarTransacoes()
        {
            foreach (var item in this.FormaPagamento.CartaoCredito.TransactionsInternal)
                item.AlteraStatusTransacaoParaCancelada();
        }

        #region Factory
        public static class Factory
        {
            public static Pedido Create(string identificadorPedido)
            {
                return new Pedido(identificadorPedido);                
            }
        }
        #endregion

    }
}
