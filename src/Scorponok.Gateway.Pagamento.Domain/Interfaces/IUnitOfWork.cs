using System;
using Scorponok.Gateway.Pagamento.Domain.Core.Commands;

namespace Scorponok.Gateway.Pagamento.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        CommandResult Commit();
    }
}
