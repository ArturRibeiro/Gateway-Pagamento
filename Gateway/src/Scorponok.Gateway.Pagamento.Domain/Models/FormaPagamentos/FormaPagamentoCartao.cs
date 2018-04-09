using Scorponok.Gateway.Pagamento.Domain.Models.Transacoes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Scorponok.Gateway.Pagamento.Domain.Models.Pedidos;

namespace Scorponok.Gateway.Pagamento.Domain.Models.FormaPagamentos
{
    public class FormaPagamentoCartao : FormaPagamento
    {
        #region Construtores
        public FormaPagamentoCartao()
        {
            
        }
        #endregion

        #region Propriedades
        public Cartao Cartao
        {
            get;
            private set;
        }

        public override string Tipo => "Cartao";
        #endregion


        #region Factory
        public class Factory
        {
            public static FormaPagamentoCartao Create(Pedido pedido, string numeoCartaoCredito, int valorCentavos, string nome)
            {
                return new FormaPagamentoCartao()
                {
                    Pedido = pedido,
                    ValorCentavos = valorCentavos,
                    Name = nome
                    , Cartao = Cartao.Factory.Create(numeoCartaoCredito, nome)
                };
            }
        }
        #endregion

    }
}
