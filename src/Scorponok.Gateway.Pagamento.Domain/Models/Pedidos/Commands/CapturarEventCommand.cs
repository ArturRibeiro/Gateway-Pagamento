using System;
using System.Collections.Generic;
using System.Text;

namespace Scorponok.Gateway.Pagamento.Domain.Models.Pedidos.Commands
{
    public class CapturarEventCommand : BaseEventCommand
    {
        #region Propriedades
        public Guid Token
        {
            get;
            private set;
        }

        public int ValorEmCentavos
        {
            get;
            private set;
        } 
        #endregion

        public CapturarEventCommand(Guid token, int valorEmCentavos)
        {
            this.Token = token;
            this.ValorEmCentavos = valorEmCentavos;
            this.AggregateId = token;
        }
    }
}
