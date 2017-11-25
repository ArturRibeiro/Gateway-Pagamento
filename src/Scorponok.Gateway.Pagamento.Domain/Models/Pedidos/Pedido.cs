using Scorponok.Gateway.Pagamento.Domain.Core.Core.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Scorponok.Gateway.Pagamento.Domain.Models.FormaPagamentos;
using Scorponok.Gateway.Pagamento.Domain.Models.Lojas;
using Scorponok.Gateway.Pagamento.Domain.Models.Pedidos;
using Scorponok.Gateway.Pagamento.Domain.Models.Transacoes;

namespace Scorponok.Gateway.Pagamento.Domain.Models
{
    public class Pedido : Entity
    {
        public Pedido()
        {
            this.Id = Guid.NewGuid();
            this.DataCriacao = DateTime.Now;
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

        public DateTime DataCriacao { get; private set; }

        public FormaPagamento FormaPagamento { get; private set; }

        //public FormaPagamentoCartaoCredito CartaoCredito { get; private set; }

        public Loja Loja { get; private set; }

        #endregion

        public void AdicionaFormaPagamentoCartaoCredito(int valorEmCentavos, string numeoCartaoCredito, string portador)
        {
            //if (this.FormaPagamento == null) this.FormaPagamento = new FormaPagamentoCartaoCredito();

            //var transacao = Transaction.Factory.Create(valorEmCentavos, numeoCartaoCredito, portador);

            //this.FormaPagamento.CartaoCredito.AdicionaTransacao(transacao);
        }

        public void AdicionaFormaPagamentoBoleto(Transacao transacao)
        {
            //if (this.FormaPagamento == null) this.FormaPagamento = new FormaPagamentoBoleto();

            //throw new NotImplementedException("AdicionaFormaPagamentoBoleto");
        }
        
        internal void CancelarTransacoes()
        {
            //foreach (var item in this.FormaPagamento.CartaoCredito.TransactionsInternal)
            //    item.AlteraStatusTransacaoParaCancelada();
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
