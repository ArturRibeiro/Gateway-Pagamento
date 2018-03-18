using Scorponok.Gateway.Pagamento.Domain.Core.Core.Models;
using System;

namespace Scorponok.Gateway.Pagamento.Domain.Models.Pedidos
{
    public class TransacaoHistorico : Entity
    {
        public TransacaoHistorico()
        {
            Id = Guid.NewGuid();
        }

        private TransacaoHistorico(LojaVO lojaVO, PedidoVO pedidoVO, FormaPagamentoVO formaPagamentoVO, TransacaoVO transacaoVO, CartaoVO cartaoVO)
        {
            LojaVO = lojaVO;
            PedidoVO = pedidoVO;
            FormaPagamentoVO = formaPagamentoVO;
            CartaoVO = cartaoVO;
            TransacaoVO = transacaoVO;
        }

        public LojaVO LojaVO { get; private set; }
        
        public PedidoVO PedidoVO { get; set; }

        public FormaPagamentoVO FormaPagamentoVO { get; private set; }

        public CartaoVO CartaoVO { get; private set; }

        public TransacaoVO TransacaoVO { get; private set; }


        #region Factory
        public static class Factory
        {
            internal static TransacaoHistorico Create(LojaVO lojaVO, PedidoVO pedidoVO, FormaPagamentoVO formaPagamentoVO, TransacaoVO transacaoVO, CartaoVO cartaoVO)
            {
                return new TransacaoHistorico(lojaVO, pedidoVO, formaPagamentoVO, transacaoVO, cartaoVO);
            }
        }
        #endregion
    }
}
