using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Scorponok.Gateway.Pagamento.Domain.Models
{
    public class FormaPagamentoCartaoCredito : FormaPagamento
    {
        public FormaPagamentoCartaoCredito()
        {
            this.TransactionsInternal = new List<Transaction>();
        }

        /// <summary>
        ///     Transações
        /// </summary>
        internal IList<Transaction> TransactionsInternal
        {
            get;
            private set;
        }

        public ReadOnlyCollection<Transaction> Transactions
        {
            get
            {
                return new ReadOnlyCollection<Transaction>(this.TransactionsInternal);
            }
        }

        #region Métodos Publicos
        public void AdicionaTransacao(Transaction transacao)
        {
            if (transacao == null) throw new ArgumentNullException("transacao");

            this.TransactionsInternal.Add(transacao);
        }
        #endregion
    }
}
