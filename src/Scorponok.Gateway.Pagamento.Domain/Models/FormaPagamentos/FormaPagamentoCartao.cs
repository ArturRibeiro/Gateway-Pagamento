using Scorponok.Gateway.Pagamento.Domain.Models.Transacoes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

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
        #endregion


    }
}
