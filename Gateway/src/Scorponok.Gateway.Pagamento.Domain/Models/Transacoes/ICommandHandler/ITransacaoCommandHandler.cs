using Scorponok.Gateway.Pagamento.Domain.Core.Events;
using Scorponok.Gateway.Pagamento.Domain.Models.Transacoes.CommandHandlers.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scorponok.Gateway.Pagamento.Domain.Models.Transacoes.ICommandHandler
{
    public interface ITransacaoCommandHandler :
         IHandler<AutorizarTransacaoEventCommand>
    {

    }
}
