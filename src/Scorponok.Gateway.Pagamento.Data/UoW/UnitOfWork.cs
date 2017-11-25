
using Scorponok.Gateway.Pagamento.Data.Context;
using Scorponok.Gateway.Pagamento.Domain.Core.Commands;
using Scorponok.Gateway.Pagamento.Domain.Interfaces;

namespace Scorponok.Gateway.Pagamento.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;

        public UnitOfWork(DataContext context)
        {
            _context = context;
        }

        public CommandResult Commit()
        {
            var rowsAffected = _context.SaveChanges();
            return new CommandResult(rowsAffected > 0);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
