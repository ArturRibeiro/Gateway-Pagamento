using Scorponok.Gateway.Pagamento.Domain.Core.Core.Models;
using System;
using System.Linq;

namespace Scorponok.Gateway.Pagamento.Domain.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        void Add(TEntity obj);

        TEntity GetById(Guid id);

        IQueryable<TEntity> GetAll();

        void Update(TEntity obj);

        void Remove(Guid id);

        int SaveChanges();

    }
}
