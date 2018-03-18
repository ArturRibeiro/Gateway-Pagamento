using Scorponok.Gateway.Pagamento.Domain.Core.Models;
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
}
