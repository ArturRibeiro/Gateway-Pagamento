using Scorponok.Gateway.Pagamento.Domain.Core.Core.Models;
using Scorponok.Gateway.Pagamento.Domain.Models.Transacoes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Scorponok.Gateway.Pagamento.Domain.Models.FormaPagamentos
{
    public class Cartao : Entity
    {
        #region Construtores
        public Cartao()
        {
            this.Id = Guid.NewGuid();
            this.Expiracao = 0;
            this.Bandeira = null;
            this.Cvv = null;
            this.Portador = null;
            this.Numero = null;
            this.TransactionsInternal = new List<Transacao>();
        }

        private Cartao(string numeoCartaoCredito, string portador)
            : this()
        {
            this.Expiracao = 042021;
            this.Bandeira = "Visa";
            this.Cvv = "845";
            this.Portador = portador;
            this.Numero = numeoCartaoCredito;
        }
        #endregion

        #region Propriedades
        /// <summary>
        /// Bandeira do cartão do cliente
        /// </summary>
        public string Bandeira
        {
            get;
            private set;
        }

        /// <summary>
        /// Número do cartão do cliente. Informar apenas números.
        /// </summary>
        public string Numero
        {
            get;
            private set;
        }

        /// <summary>
        /// Mês/Ano de expiração do cartão
        /// </summary>
        public int Expiracao
        {
            get;
            private set;
        }

        /// <summary>
        /// Nome do portador do cartão
        /// </summary>
        public string Portador
        {
            get;
            private set;
        }

        /// <summary>
        /// Código de segurança do cartão
        /// </summary>
        public string Cvv
        {
            get;
            private set;
        }
        #endregion

        // <summary>
        //     Transações
        // </summary>
        internal IList<Transacao> TransactionsInternal
        {
            get;
            private set;
        }

        public ReadOnlyCollection<Transacao> Transactions
        {
            get
            {
                return new ReadOnlyCollection<Transacao>(this.TransactionsInternal);
            }
        }

        #region Métodos Publicos
        public void AdicionaTransacao(Transacao transacao)
        {
            if (transacao == null) throw new ArgumentNullException("transacao");

            //transacao.FormaPagamento = this;

            this.TransactionsInternal.Add(transacao);
        }
        #endregion

        #region Factory
        public static class Factory
        {
            public static Cartao Create(string numeroCartaoCredito, string portador)
            {
                var cartao = new Cartao(numeroCartaoCredito, portador);

                cartao.AdicionaTransacao(Transacao.Factory.Create(82822, numeroCartaoCredito, "TESTET TESTE"));

                return cartao;
            }
        }

        #endregion
    }
}
