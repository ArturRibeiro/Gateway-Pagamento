﻿using Scorponok.Gateway.Pagamento.Domain.Core.Core.Models;
using Scorponok.Gateway.Pagamento.Domain.Models.FormaPagamentos;

namespace Scorponok.Gateway.Pagamento.Domain.Models.Transacoes
{
    public class Transacao : Entity
    {
        #region Construtores
        public Transacao()
        {
            //this.ValorCentavos = 0;
            //this.CartaoCredito = null;
            this.NumeroParcelas = 0;
            this.Status = TransacaoStatus.Criado;
        }

        private Transacao(int valorEmCentavos, string numeroCartaoCredito, string portador)
            : this()
        {
            //this.ValorCentavos = valorEmCentavos;


            //this.CartaoCredito = Cartao.Factory.Create(numeroCartaoCredito, portador);
        }
        #endregion

        #region Propriedades
        ///// <summary>
        ///// Valor da transação em centavos. R$ 100,00 = 10000
        ///// </summary>
        //public int ValorCentavos
        //{
        //    get;
        //    private set;
        //}

        /// <summary>
        /// 
        /// </summary>
        public Cartao Cartao
        {
            get;
            private set;
        }

        /// <summary>
        /// Número de Parcelas
        /// </summary>
        public int NumeroParcelas
        {
            get;
            private set;
        }

        public TransacaoStatus Status
        {
            get;
            private set;
        }

        internal void AlteraStatusTransacaoParaCancelada()
        {
            this.Status = TransacaoStatus.Cancelado;
        }
        #endregion

        #region Factory
        public static class Factory
        {
            public static Transacao Create(int valorEmCentavos, string numeroCartaoCredito, string portador)
            {
                return new Transacao(valorEmCentavos, numeroCartaoCredito, portador);
            }
        }
        #endregion
    }
}
