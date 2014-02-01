using System.Collections.Generic;
using System.Linq;
using FunnelWeb.Domain.Dao;
using FunnelWeb.Domain.Model;

namespace FunnelWeb.Domain.Interfaces.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Get(object id);
        IQueryable<TEntity> GetQueryable();
        IEnumerable<TEntity> FindAll();
        IEnumerable<TEntity> Find(IQuery<TEntity> query);
        PagedResult<TEntity> Find(IPagedQuery<TEntity> query, int pageNumber, int itemsPerPage);
        TEntity FindFirst(IQuery<TEntity> query);
        TEntity FindFirstOrDefault(IQuery<TEntity> query);
        TEntity FindFirstOrDefault(IPagedQuery<TEntity> query);
        void Execute(ICommand command);
        void Add(object entity);
        void Remove(object entity);
    }
}
