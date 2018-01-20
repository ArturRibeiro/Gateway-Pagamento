using Scorponok.Gateway.Pagamento.Domain.Core.Core.Models;
using System;

namespace Scorponok.Gateway.Pagamento.Domain.Models.FormaPagamentos
{
    public abstract class FormaPagamento : Entity
    {
        protected FormaPagamento()
        {
            this.Id = Guid.NewGuid();
        }

        public abstract string Tipo { get; }

        public int ValorCentavos { get; protected set; }

        public string Name { get; protected set; }

        public Pedido Pedido { get; protected set; }
    }
}
