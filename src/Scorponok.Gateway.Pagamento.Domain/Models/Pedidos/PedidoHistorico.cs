using Scorponok.Gateway.Pagamento.Domain.Core.Core.Models;
using Scorponok.Gateway.Pagamento.Domain.Core.Models;
using Scorponok.Gateway.Pagamento.Domain.Models.Transacoes;
using System;

namespace Scorponok.Gateway.Pagamento.Domain.Models.Pedidos
{

    public class PedidoVO : ValueObject<PedidoVO>
    {
        public Guid PedidoId { get; private set; }

        public string PedidoIdentificador { get; private set; }

        public DateTime PedidoDataCriacao { get; private set; }
    }

    public class LojaVO : ValueObject<LojaVO>
    {
        public Guid LojaId { get; private set; }

        public string LojaNome { get; private set; }
    }

    public class FormaPagamentoVO : ValueObject<FormaPagamentoVO>
    {
        public string FormaPagamentoNome { get; private set; }

        public int FormaPagamentoValorCentavos { get; private set; }

        public string FormaPagamentoTipo { get; private set; }
    }

    public class CartaoVO : ValueObject<CartaoVO>
    {
        public string CartaoBandeira { get; private set; }

        public string CartaoCvv { get; private set; }

        public int CartaoExpiracao { get; private set; }

        public string CartaoNumero { get; private set; }

        public string CartaoPortador { get; private set; }
    }

    public class TransacaoVO : ValueObject<CartaoVO>
    {
        public int TransacaoNumeroParcelas { get; private set; }

        public string TransacaoStatus { get; private set; }
    }

    public class TransacaoHistorico : Entity
    {
        public TransacaoHistorico()
        {

        }
        
        public LojaVO LojaVO { get; private set; }
        
        public PedidoVO PedidoVO { get; set; }

        public FormaPagamentoVO FormaPagamentoVO { get; private set; }

        public CartaoVO CartaoVO { get; private set; }

        public TransacaoVO TransacaoVO { get; private set; }


        #region Factory
        public static class Factory
        {
 
            internal static TransacaoHistorico Create(Guid lojaId, string nome, Guid pedidoId, string identificadorPedido, DateTime dataCriacao, string formaPagamento, int valorCentavos, string name, int numeroParcelas, TransacaoStatus status)
            {
                return new TransacaoHistorico()
                {
                    //LojaId = lojaId,
                    //LojaNome = nome,
                    //PedidoId = pedidoId,
                    //PedidoIdentificador = identificadorPedido,
                    //PedidoDataCriacao = dataCriacao,
                    //FormaPagamentoNome = formaPagamento,
                    //FormaPagamentoValorCentavos = valorCentavos,
                    //FormaPagamentoTipo = name,
                    //TransacaoNumeroParcelas = numeroParcelas,
                    //TransacaoStatus = status.ToString()
                };
            }
        }
        #endregion
    }
}
