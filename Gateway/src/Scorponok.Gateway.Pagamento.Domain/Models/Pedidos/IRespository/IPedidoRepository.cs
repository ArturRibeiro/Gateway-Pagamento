﻿using Scorponok.Gateway.Pagamento.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scorponok.Gateway.Pagamento.Domain.Models.Pedidos.IRespository
{
    public interface IPedidoRepository : IRepository<Pedido>
    {
        Pedido Create(Guid lojaToken, string identificadorPedido, int valorCentavos, string numeroCartaoCredito, string portador);
    }
}
