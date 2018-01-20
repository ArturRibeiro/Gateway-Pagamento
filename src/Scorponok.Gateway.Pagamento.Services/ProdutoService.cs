using Scorponok.Gateway.Pagamento.Domain.Models.Pedidos.IService;
using System;
using Scorponok.Gateway.Pagamento.Domain.Models;
using Scorponok.Gateway.Pagamento.Infra.Cross.Cutting.Utility;
using Scorponok.Gateway.Pagamento.Domain.Models.Lojas;
using Scorponok.Gateway.Pagamento.Domain.Models.Pedidos.IRespository;

namespace Scorponok.Gateway.Pagamento.Services.Entity
{
    public class ProdutoService : IProdutoService
    {
        private readonly IPedidoRepository _pedidoRepository;

        public ProdutoService(IPedidoRepository produtoRepository)
        {
            _pedidoRepository = produtoRepository;
        }

        public Pedido Save(Guid lojaToken, string identificadorPedido, int valorCentavos, string numeroCartaoCredito, string portador)
        {
            Verify.ThrowIf(identificadorPedido == null, () => new ArgumentNullException("identificadorPedido"));
            Verify.ThrowIf(valorCentavos <= 0, () => new ArgumentNullException("valorCentavos"));
            Verify.ThrowIf(numeroCartaoCredito == null, () => new ArgumentNullException("numeroCartaoCredito"));
            Verify.ThrowIf(portador == null, () => new ArgumentNullException("portador"));

            var loja = new Loja(lojaToken);// _produtoRepository.GetById(lojaToken);

            var pedido = Pedido.Factory.Create(loja, identificadorPedido, valorCentavos, numeroCartaoCredito, portador);

            _pedidoRepository.Create(pedido);

            return pedido;
        }
    }
}
