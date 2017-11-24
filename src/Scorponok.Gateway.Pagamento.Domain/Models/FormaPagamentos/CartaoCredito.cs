using Scorponok.Gateway.Pagamento.Domain.Core.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scorponok.Gateway.Pagamento.Domain.Models
{
    public class CartaoCredito : Entity
    {
        #region Construtores
        public CartaoCredito()
        {
            this.AnoExpiracao = 0;
            this.MesExpiracao = 0;
            this.Bandeira = null;
            this.Cvv = null;
            this.Portador = null;
            this.Numero = null;
        }

        private CartaoCredito(string numeoCartaoCredito, string portador)
            : this()
        {
            this.AnoExpiracao = 2021;
            this.MesExpiracao = 04;
            this.Bandeira = "Visa";
            this.Cvv = "845";
            this.Portador = portador;
            this.Numero = numeoCartaoCredito;
        } 
        #endregion

        /// <summary>
        /// Bandeira do cartão do cliente
        /// </summary>
        public string Bandeira { get; private set; }

        /// <summary>
        /// Número do cartão do cliente. Informar apenas números.
        /// </summary>
        public string Numero { get; private set; }

        /// <summary>
        /// Mês de expiração do cartão
        /// </summary>
        public int MesExpiracao { get; private set; }

        /// <summary>
        /// Ano de expiração do cartão
        /// </summary>
        public int AnoExpiracao { get; private set; }

        /// <summary>
        /// Nome do portador do cartão
        /// </summary>
        public string Portador { get; private set; }

        /// <summary>
        /// Código de segurança do cartão
        /// </summary>
        public string Cvv { get; private set; }

        #region Factory
        public static class Factory
        {
            public static CartaoCredito Create(string numeroCartaoCredito, string portador)
            {
                return new CartaoCredito(numeroCartaoCredito, portador);
            }
        }
        #endregion
    }
}
