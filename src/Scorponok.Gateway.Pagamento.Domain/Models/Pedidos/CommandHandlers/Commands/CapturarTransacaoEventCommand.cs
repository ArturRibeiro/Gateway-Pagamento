using System;
using System.Collections.Generic;
using System.Text;

namespace Scorponok.Gateway.Pagamento.Domain.Models.Pedidos.CommandHandlers.Commands
{
    public class CapturarTransacaoEventCommand : BaseEventCommand
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

        public CapturarTransacaoEventCommand(Guid token, int valorEmCentavos)
        {
            this.Token = token;
            this.ValorEmCentavos = valorEmCentavos;
            this.AggregateId = token;
        }
    }
}
