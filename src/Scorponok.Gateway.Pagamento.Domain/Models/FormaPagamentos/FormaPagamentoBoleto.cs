using Scorponok.Gateway.Pagamento.Domain.Core.Core.Models;

namespace Scorponok.Gateway.Pagamento.Domain.Models.FormaPagamentos
{
    public class FormaPagamentoBoleto : Entity
    {
        //internal FormaPagamentoBoleto()
        //{

        //}
        public Pedido Pedido { get; private set; }
    }
}
