using Scorponok.Gateway.Pagamento.Domain.Core.Core.Models;
using Scorponok.Gateway.Pagamento.Domain.Models.Transacoes;
using System;

namespace Scorponok.Gateway.Pagamento.Domain.Models.Pedidos
{
    public class PedidoHistorico : Entity
    {
        #region Loja
        public Guid LojaId { get; private set; }

        public string Nome { get; private set; }
        #endregion

        #region Pedido

        public Guid PedidoId { get; private set; }

        public string IdentificadorPedido { get; private set; }

        public DateTime DataCriacaoPedido { get; private set; }

        #endregion

        #region Forma de Pagamento

        public string FormaPagamentoDescricao { get; private set; }

        public int ValorCentavos { get; private set; }

        public string Name { get; private set; }

        #endregion

        #region Transação

        public int NumeroParcelas { get; private set; }

        public TransacaoStatus StatusTransacao { get; private set; }
        #endregion

        #region Factory
        public static class Factory
        {
 
            internal static PedidoHistorico Create(Guid lojaId, string nome, Guid pedidoId, string identificadorPedido, DateTime dataCriacao, string formaPagamento, int valorCentavos, string name, int numeroParcelas, TransacaoStatus status)
            {
                return new PedidoHistorico()
                {
                    LojaId = lojaId,
                    Nome = nome,
                    PedidoId = pedidoId,
                    IdentificadorPedido = identificadorPedido,
                    DataCriacaoPedido = dataCriacao,
                    FormaPagamentoDescricao = formaPagamento,
                    ValorCentavos = valorCentavos,
                    Name = name,
                    NumeroParcelas = numeroParcelas,
                    StatusTransacao = status
                };
            }
        }
        #endregion
    }
}
