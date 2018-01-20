using Scorponok.Gateway.Pagamento.Cross.Cutting.Data.Context;
using Scorponok.Gateway.Pagamento.Domain.Models;
using Scorponok.Gateway.Pagamento.Domain.Models.Lojas;
using Scorponok.Gateway.Pagamento.Domain.Models.Pedidos.IRespository;

namespace Scorponok.Gateway.Pagamento.Cross.Cutting.Data.Repositorys
{
    public class PedidoRepository : RepositoryBase<Pedido>, IPedidoRepository
    {
        public PedidoRepository(DataContext context)
            : base(context)
        {

        }

        public override void Create(Pedido pedido)
        {
            _dataContext.Set<Loja>().Attach(pedido.Loja);

            base.Create(pedido);
        }
    }
}
