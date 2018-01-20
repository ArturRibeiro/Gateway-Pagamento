using System;
using System.Collections.Generic;
using System.Text;

namespace Scorponok.Gateway.Pagamento.Domain.Models.Pedidos.IService
{
    public interface IProdutoService
    {
        Pedido Save(Guid lojaToken, string identificadorPedido, int valorCentavos, string numeroCartaoCredito, string portador);
    }
}
