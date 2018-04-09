using System;
using System.Linq;
using Scorponok.Gateway.Pagamento.Domain.Core.Models;

namespace Scorponok.Gateway.Pagamento.Domain.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        void Create(TEntity obj);

        TEntity GetById(Guid id);

        IQueryable<TEntity> GetAll();

        void Update(TEntity obj);

        void Remove(Guid id);

        int SaveChanges();

    }
}
