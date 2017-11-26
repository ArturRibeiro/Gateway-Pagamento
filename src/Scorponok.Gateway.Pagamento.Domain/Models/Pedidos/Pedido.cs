﻿using Scorponok.Gateway.Pagamento.Domain.Core.Core.Models;
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
        #region Construtores
        public Pedido()
        {
            this.Id = Guid.NewGuid();
            this.DataCriacao = DateTime.Now;
        }

        private Pedido(Loja loja, string IdentificadorPedido, int valorEmCentavos, string numeoCartaoCredito, string portador)
            : this()
        {
            this.Loja = loja;

            this.IdentificadorPedido = numeoCartaoCredito;

            this.AdicionaFormaPagamentoCartao(valorEmCentavos, numeoCartaoCredito, portador);
        } 
        #endregion

        #region Propriedades
        /// <summary>
        ///     Identificador do pedido na sua base
        /// </summary>
        public string IdentificadorPedido { get; private set; }

        public DateTime DataCriacao { get; private set; }

        public FormaPagamento FormaPagamento { get; private set; }
        
        public Loja Loja { get; private set; }

        #endregion

        public void AdicionaFormaPagamentoCartao(int valorEmCentavos, string numeoCartaoCredito, string portador)
        {
            this.FormaPagamento = FormaPagamentoCartao.Factory.Create(this, numeoCartaoCredito, valorEmCentavos, portador);
        }

        public void AdicionaFormaPagamentoBoleto(Transacao transacao)
        {
            //if (this.FormaPagamento == null) this.FormaPagamento = new FormaPagamentoBoleto();

            //throw new NotImplementedException("AdicionaFormaPagamentoBoleto");
        }
        
        internal void CancelarTransacoes()
        {

        }

        #region Factory
        public static class Factory
        {
            internal static Pedido AutorizarPedido(Loja loja, string IdentificadorPedido, int valorCentavos, string numeroCartaoCredito, string portador)
            {
                return new Pedido(loja, IdentificadorPedido, valorCentavos, numeroCartaoCredito, portador);
            }
        }
        #endregion

    }
}
