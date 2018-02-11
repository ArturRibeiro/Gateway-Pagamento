using Scorponok.Gateway.Pagamento.Domain.Models;
using Scorponok.Gateway.Pagamento.Domain.Models.Pedidos.IService;

namespace Scorponok.Gateway.Pagamento.Services.Entity
{
    public class PedidoService : IPedidoService
    {
        public PedidoService()
        {

        }

        public Pedido AutorizaPagamentoAdquirente(Pedido pedido)
        {
            return pedido;
        }
    }
}
