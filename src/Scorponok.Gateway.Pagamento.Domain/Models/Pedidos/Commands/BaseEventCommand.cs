using Scorponok.Gateway.Pagamento.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scorponok.Gateway.Pagamento.Domain.Models.Pedidos.Commands
{
    public abstract class BaseEventCommand : Command
    {
        /// <summary>
        ///     Identificador do pedido na sua base
        /// </summary>
        public string IdentificadorPedido
        {
            get;
            protected set;
        }
    }
}
