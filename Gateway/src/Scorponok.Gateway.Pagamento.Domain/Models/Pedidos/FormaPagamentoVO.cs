using Scorponok.Gateway.Pagamento.Domain.Core.Models;

namespace Scorponok.Gateway.Pagamento.Domain.Models.Pedidos
{
    public class FormaPagamentoVO : ValueObject<FormaPagamentoVO>
    {
        public FormaPagamentoVO(int formaPagamentoValorCentavos, string formaPagamentoTipo)
        {
            FormaPagamentoValorCentavos = formaPagamentoValorCentavos;
            FormaPagamentoTipo = formaPagamentoTipo;
        }

        public int FormaPagamentoValorCentavos { get; private set; }

        public string FormaPagamentoTipo { get; private set; }

        internal static FormaPagamentoVO Create(int valorCentavos, string formaPagamentoTipo)
        {
            return new FormaPagamentoVO(valorCentavos, formaPagamentoTipo);
        }
    }
}