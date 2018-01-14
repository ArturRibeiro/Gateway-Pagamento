using Scorponok.Gateway.Pagamento.Domain.Models.Lojas;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scorponok.Gateway.Pagamento.Domain.Models.Pedidos.IService
{
    public interface ILojaService
    {
        bool CancelarPedido(Pedido pedido);

        Loja Save(Guid lojaToken, string identificadorPedido, int valorCentavos, string numeroCartaoCredito, string portador);
    }
}
