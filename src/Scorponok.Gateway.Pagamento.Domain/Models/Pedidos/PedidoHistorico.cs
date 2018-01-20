using Scorponok.Gateway.Pagamento.Domain.Core.Core.Models;
using Scorponok.Gateway.Pagamento.Domain.Core.Models;
using Scorponok.Gateway.Pagamento.Domain.Models.Transacoes;
using System;

namespace Scorponok.Gateway.Pagamento.Domain.Models.Pedidos
{

    public class PedidoVO : ValueObject<PedidoVO>
    {
        public PedidoVO(Guid pedidoId, string pedidoIdentificador, DateTime pedidoDataCriacao)
        {
            PedidoId = pedidoId;
            PedidoIdentificador = pedidoIdentificador;
            PedidoDataCriacao = pedidoDataCriacao;
        }

        public Guid PedidoId { get; private set; }

        public string PedidoIdentificador { get; private set; }

        public DateTime PedidoDataCriacao { get; private set; }

        internal static PedidoVO Create(Guid id, string identificadorPedido, DateTime dataCriacao)
        {
            return new PedidoVO(id, identificadorPedido, dataCriacao);
        }
    }

    public class LojaVO : ValueObject<LojaVO>
    {
        private LojaVO(Guid lojaId, string lojaNome)
        {
            LojaId = lojaId;
            LojaNome = lojaNome;
        }

        public Guid LojaId { get; private set; }

        public string LojaNome { get; private set; }

        public static LojaVO Create(Guid lojaId, string lojaNome)
        {
            return new LojaVO(lojaId, lojaNome);
        }
    }

    public class FormaPagamentoVO : ValueObject<FormaPagamentoVO>
    {
        public FormaPagamentoVO(int formaPagamentoValorCentavos, string formaPagamentoTipo)
        {
            FormaPagamentoValorCentavos = formaPagamentoValorCentavos;
            FormaPagamentoTipo = formaPagamentoTipo;
        }

        public int FormaPagamentoValorCentavos { get; private set; }

        public string FormaPagamentoTipo { get; private set; }

        internal static FormaPagamentoVO Create(int valorCentavos, string formaPagamentoTipo)
        {
            return new FormaPagamentoVO(valorCentavos, formaPagamentoTipo);
        }
    }

    public class CartaoVO : ValueObject<CartaoVO>
    {
        public CartaoVO(string cartaoBandeira, int cartaoExpiracao, string cartaoNumero, string cartaoPortador)
        {
            CartaoBandeira = cartaoBandeira;
            CartaoExpiracao = cartaoExpiracao;
            CartaoNumero = cartaoNumero;
            CartaoPortador = cartaoPortador;
        }

        public string CartaoBandeira { get; private set; }

        public string CartaoCvv { get; private set; }

        public int CartaoExpiracao { get; private set; }

        public string CartaoNumero { get; private set; }

        public string CartaoPortador { get; private set; }

        internal static CartaoVO Create(string bandeira, int expiracao, string numero, string portador)
        {
            return new CartaoVO(bandeira, expiracao, numero, portador);
        }
    }

    public class TransacaoVO : ValueObject<CartaoVO>
    {
        public TransacaoVO(int transacaoNumeroParcelas, string transacaoStatus)
        {
            TransacaoNumeroParcelas = transacaoNumeroParcelas;
            TransacaoStatus = transacaoStatus;
        }

        public int TransacaoNumeroParcelas { get; private set; }

        public string TransacaoStatus { get; private set; }

        internal static TransacaoVO Create(int numeroParcelas, TransacaoStatus status)
        {
            return new TransacaoVO(numeroParcelas, status.ToString());
        }

        
    }

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
