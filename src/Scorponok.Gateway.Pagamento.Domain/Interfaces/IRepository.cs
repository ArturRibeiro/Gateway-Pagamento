using Scorponok.Gateway.Pagamento.Domain.Core.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Scorponok.Gateway.Pagamento.Domain.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        void Add(TEntity entity);

        TEntity Save(TEntity entity);

        void Remove(TEntity entity);

        TEntity Updade(TEntity entity);

        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

    }
}
