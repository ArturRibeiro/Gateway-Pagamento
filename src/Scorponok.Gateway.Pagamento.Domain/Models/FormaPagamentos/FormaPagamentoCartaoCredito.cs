using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Scorponok.Gateway.Pagamento.Domain.Core.Core.Models;
using Scorponok.Gateway.Pagamento.Domain.Models.Pedidos;

namespace Scorponok.Gateway.Pagamento.Domain.Models.FormaPagamentos
{
    public class FormaPagamentoCartaoCredito : Entity
    {
        public FormaPagamentoCartaoCredito()
        {
            //this.TransactionsInternal = new List<Transacao>();
        }

        /// <summary>
        ///     Transações
        /// </summary>
        //internal IList<Transacao> TransactionsInternal
        //{
        //    get;
        //    private set;
        //}

        //public ReadOnlyCollection<Transacao> Transactions
        //{
        //    get
        //    {
        //        return new ReadOnlyCollection<Transacao>(this.TransactionsInternal);
        //    }
        //}

        public Pedido Pedido { get; private set; }

        #region Métodos Publicos
        public void AdicionaTransacao(Transacao transacao)
        {
            //if (transacao == null) throw new ArgumentNullException("transacao");

            //this.TransactionsInternal.Add(transacao);
        }
        #endregion
    }
}
