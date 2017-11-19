using System;
using System.Collections.Generic;
using System.Text;

namespace Scorponok.Gateway.Pagamento.Domain.Models.Pedidos.Commands
{
    public class AutorizarEventCommand : BaseEventCommand
    {
        #region Propriedades
        public int ValorCentavos
        {
            get;
            private set;
        }

        public string NumeroCartaoCredito
        {
            get;
            private set;
        }

        public string Portador
        {
            get;
            private set;
        }
        #endregion

        public AutorizarEventCommand(string identificadorPedido, int valorEmCentavos, string numeroCartaoCredito, string portador)
        {
            this.IdentificadorPedido = identificadorPedido;
            this.ValorCentavos = valorEmCentavos;
            this.NumeroCartaoCredito = numeroCartaoCredito;
            this.Portador = portador;
        }
    }
}
