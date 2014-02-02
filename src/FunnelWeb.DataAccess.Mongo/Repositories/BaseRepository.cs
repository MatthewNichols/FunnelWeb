using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using FunnelWeb.Domain.Dao;
using FunnelWeb.Domain.Interfaces;
using FunnelWeb.Domain.Interfaces.Repositories;

namespace FunnelWeb.DataAccess.Mongo.Repositories
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public ISiteContext SiteContext { get; set; }

        #region Implementation of IRepository

        public TEntity Get(object id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> GetQueryable()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> FindAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> Find(IQuery<TEntity> query)
        {
            throw new NotImplementedException();
        }

        public PagedResult<TEntity> Find(IPagedQuery<TEntity> query, int pageNumber, int itemsPerPage)
        {
            throw new NotImplementedException();
        }

        public TEntity FindFirst(IQuery<TEntity> query)
        {
            throw new NotImplementedException();
        }

        public TEntity FindFirstOrDefault(IQuery<TEntity> query)
        {
            throw new NotImplementedException();
        }

        public TEntity FindFirstOrDefault(IPagedQuery<TEntity> query)
        {
            throw new NotImplementedException();
        }

        public void Execute(ICommand command)
        {
            throw new NotImplementedException();
        }

        public void Add(object entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(object entity)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
