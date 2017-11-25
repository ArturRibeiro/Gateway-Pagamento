using Scorponok.Gateway.Pagamento.Domain.Core.Core.Models;

namespace Scorponok.Gateway.Pagamento.Domain.Models.FormaPagamentos
{
    public abstract class FormaPagamento : Entity
    {
        public int ValorCentavos { get; private set; }

        public string Name { get; private set; }

        public Pedido Pedido { get; private set; }
    }
}
