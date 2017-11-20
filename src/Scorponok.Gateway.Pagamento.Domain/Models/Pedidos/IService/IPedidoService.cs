using System;
using System.Collections.Generic;
using System.Text;

namespace Scorponok.Gateway.Pagamento.Domain.Models.Pedidos.IService
{
    public interface IPedidoService
    {
        bool CancelarPedido(Pedido pedido);
    }
}
