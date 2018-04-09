using System;
using Scorponok.Gateway.Pagamento.Cross.Cutting.Data.Context;
using Scorponok.Gateway.Pagamento.Domain.Models;
using Scorponok.Gateway.Pagamento.Domain.Models.Lojas;
using Scorponok.Gateway.Pagamento.Domain.Models.Pedidos;
using Scorponok.Gateway.Pagamento.Domain.Models.Pedidos.IRespository;
using Scorponok.Shared.Utility;

namespace Scorponok.Gateway.Pagamento.Cross.Cutting.Data.Repositorys
{
    public class PedidoRepository : RepositoryBase<Pedido>, IPedidoRepository
    {
        public PedidoRepository(DataContext context)
            : base(context)
        {

        }

        public Pedido Create(Guid lojaToken, string identificadorPedido, int valorCentavos, string numeroCartaoCredito, string portador)
        {
            Verify.ThrowIf(identificadorPedido == null, () => new ArgumentNullException("identificadorPedido"));
            Verify.ThrowIf(valorCentavos <= 0, () => new ArgumentNullException("valorCentavos"));
            Verify.ThrowIf(numeroCartaoCredito == null, () => new ArgumentNullException("numeroCartaoCredito"));
            Verify.ThrowIf(portador == null, () => new ArgumentNullException("portador"));

            var loja = new Loja(lojaToken);

            var pedido = Pedido.Factory.Create(loja, identificadorPedido, valorCentavos, numeroCartaoCredito, portador);

            _dataContext.Set<Loja>().Attach(pedido.Loja);
            _dataContext.Entry(pedido.Loja).Reload();

            this.Create(pedido);

            return pedido;
        }
    }
}
