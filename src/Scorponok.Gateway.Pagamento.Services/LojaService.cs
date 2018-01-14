using Scorponok.Gateway.Pagamento.Domain.Models;
using Scorponok.Gateway.Pagamento.Domain.Models.Lojas;
using Scorponok.Gateway.Pagamento.Domain.Models.Lojas.IRespository;
using Scorponok.Gateway.Pagamento.Domain.Models.Pedidos.IService;
using Scorponok.Gateway.Pagamento.Infra.Cross.Cutting.Utility;
using System;

namespace Scorponok.Gateway.Pagamento.Services.Entity
{
    public class LojaService : ILojaService
    {
        private readonly ILojaRepository _lojaRepository;

        public LojaService(ILojaRepository lojaRepository)
        {
            _lojaRepository = lojaRepository;
        }

        public bool CancelarPedido(Pedido pedido)
        {
            return true;
        }

        public Loja Save(Guid lojaToken, string identificadorPedido, int valorCentavos, string numeroCartaoCredito, string portador)
        {
            Verify.ThrowIf(identificadorPedido == null, () => new ArgumentNullException("identificadorPedido"));
            Verify.ThrowIf(valorCentavos <=0, () => new ArgumentNullException("valorCentavos"));
            Verify.ThrowIf(numeroCartaoCredito == null, () => new ArgumentNullException("numeroCartaoCredito"));
            Verify.ThrowIf(portador == null, () => new ArgumentNullException("portador"));

            var loja = _lojaRepository.GetById(lojaToken);

            var pedido = Pedido.Factory.Create(loja, identificadorPedido, valorCentavos, numeroCartaoCredito, portador);

            loja.AdicionaPedido(pedido);            

            return loja;
        }
    }
}
