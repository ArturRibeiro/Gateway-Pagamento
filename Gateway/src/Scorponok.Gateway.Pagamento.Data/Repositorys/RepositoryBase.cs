using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Scorponok.Gateway.Pagamento.Cross.Cutting.Data.Context;
using Scorponok.Gateway.Pagamento.Domain.Core.Models;
using Scorponok.Gateway.Pagamento.Domain.Interfaces;

namespace Scorponok.Gateway.Pagamento.Cross.Cutting.Data.Repositorys
{
    public class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected readonly DataContext _dataContext;
        protected readonly DbSet<TEntity> _dbSet;

        public RepositoryBase(DataContext context)
        {
            _dataContext = context;
            _dbSet = _dataContext.Set<TEntity>();
        }

        public virtual void Create(TEntity obj)
        {
            _dbSet.Add(obj);
        }

        public virtual TEntity GetById(Guid id)
        {
            return _dbSet.Find(id);
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return _dbSet;
        }

        public virtual void Update(TEntity obj)
        {
            _dbSet.Update(obj);
        }

        public virtual void Remove(Guid id)
        {
            _dbSet.Remove(_dbSet.Find(id));
        }

        public int SaveChanges()
        {
            return _dataContext.SaveChanges();
        }

        public void Dispose()
        {
            _dataContext.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
