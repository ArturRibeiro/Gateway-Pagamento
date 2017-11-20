using Scorponok.Gateway.Pagamento.Domain.Models;
using Scorponok.Gateway.Pagamento.Domain.Models.Pedidos.IService;
using System;

namespace Scorponok.Gateway.Pagamento.Services
{
    public class PedidoService : IPedidoService
    {
        public bool CancelarPedido(Pedido pedido)
        {
            return true;
        }
    }
}
