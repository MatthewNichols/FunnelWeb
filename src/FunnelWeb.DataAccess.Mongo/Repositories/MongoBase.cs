using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FunnelWeb.Domain.Model;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace FunnelWeb.DataAccess.Mongo.Repositories
{
    public abstract class MongoBase<TEntity>
    {
        #region Member Vars and constants

        protected readonly MongoCollection<TEntity> collection;

        #endregion

        #region Constructors

        public MongoBase(string connectionString)
        {
            var mongoUrl = new MongoUrl(connectionString);
            var client = new MongoClient(mongoUrl);
            var mongoServer = client.GetServer();
            var mongoDatabase = mongoServer.GetDatabase(mongoUrl.DatabaseName);
            collection = mongoDatabase.GetCollection<TEntity>(DefaultCollectionName);
        }

        #endregion

        protected IQueryable<TEntity> QueryableCollection
        {
            get { return collection.AsQueryable(); }
        }

        public abstract string DefaultCollectionName { get; }

    }
}
