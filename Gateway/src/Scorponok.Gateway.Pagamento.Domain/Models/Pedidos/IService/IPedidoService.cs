﻿namespace Scorponok.Gateway.Pagamento.Domain.Models.Pedidos.IService
{
    public interface IPedidoService
    {
        Pedido AutorizaPagamentoAdquirente(Pedido pedido);
    }
}