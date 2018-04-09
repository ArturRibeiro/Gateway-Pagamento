using System;
using System.Collections.Generic;
using Scorponok.Gateway.Pagamento.Domain.Core.Models;
using Scorponok.Gateway.Pagamento.Domain.Models.FormaPagamentos;
using Scorponok.Gateway.Pagamento.Domain.Models.Lojas;
using Scorponok.Gateway.Pagamento.Domain.Models.Pedidos.VOs;
using Scorponok.Gateway.Pagamento.Domain.Models.Transacoes;

namespace Scorponok.Gateway.Pagamento.Domain.Models.Pedidos
{
    public class Pedido : Entity
    {
        #region Construtores
        public Pedido()
        {
            this.Id = Guid.NewGuid();
            this.DataCriacao = DateTime.Now;
            this.PedidoHistoricos = new List<TransacaoHistorico>();
        }

        internal Pedido(Loja loja, string IdentificadorPedido, int valorEmCentavos, string numeoCartaoCredito, string portador)
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

        public IList<TransacaoHistorico> PedidoHistoricos { get; private set; }

        #endregion

        public void AdicionaFormaPagamentoCartao(int valorEmCentavos, string numeoCartaoCredito, string portador)
        {
            var formaPagamento = FormaPagamentoCartao.Factory.Create(this, numeoCartaoCredito, valorEmCentavos, portador);

            foreach (var item in formaPagamento.Cartao.Transactions)
            {
                var lojaVO = LojaVO.Create(Loja.Id, Loja.Nome);
                var pedidoVO = PedidoVO.Create(this.Id, this.IdentificadorPedido, this.DataCriacao);
                var transacaoVO = TransacaoVO.Create(item.NumeroParcelas, item.Status);
                var formaPagamentoVO = FormaPagamentoVO.Create(formaPagamento.ValorCentavos, formaPagamento.Tipo);
                var cartaoVO = CartaoVO.Create(formaPagamento.Cartao.Bandeira, formaPagamento.Cartao.Expiracao, formaPagamento.Cartao.Numero, formaPagamento.Cartao.Portador);


                PedidoHistoricos.Add(TransacaoHistorico.Factory.Create(
                     lojaVO
                    , pedidoVO
                    , formaPagamentoVO
                    , transacaoVO
                    , cartaoVO));
            }


            this.FormaPagamento = formaPagamento;
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
            public static Pedido Create(Loja loja, string identificadorPedido, int valorCentavos, string numeroCartaoCredito, string portador)
            {
                return new Pedido(loja, identificadorPedido, valorCentavos, numeroCartaoCredito, portador);
            }
        }
        #endregion

    }
}
