using Scorponok.Gateway.Pagamento.Domain.Enuns;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scorponok.Gateway.Pagamento.Domain.Models.Pedidos.CommandHandlers.Commands
{
    public class AutorizarPedidoEventCommand : BaseEventCommand
    {
        #region Propriedades
        public Guid LojaToken
        {
            get;
            private set;
        }

        /// <summary>
        ///     Identificador do pedido na sua base
        /// </summary>
        public string IdentificadorPedido
        {
            get;
            private set;
        }

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

        public AutorizarPedidoEventCommand(Guid lojaToken, Operadora operadora, string identificadorPedido, int valorEmCentavos, string numeroCartaoCredito, string portador)
        {
            this.LojaToken = lojaToken;
            this.IdentificadorPedido = identificadorPedido;
            this.ValorCentavos = valorEmCentavos;
            this.NumeroCartaoCredito = numeroCartaoCredito;
            this.Portador = portador;
        }
    }
}
