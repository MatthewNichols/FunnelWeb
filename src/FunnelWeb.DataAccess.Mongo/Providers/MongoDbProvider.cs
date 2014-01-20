using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FunnelWeb.Domain.Interfaces;

namespace FunnelWeb.DataAccess.Mongo.Providers
{
    public class MongoDbProvider : IDatabaseProvider
    {
        public string DefaultConnectionString { get; private set; }
        public bool SupportSchema { get; private set; }
        public bool SupportFuture { get; private set; }
        public bool SupportsFullText { get; private set; }
        public bool TryConnect(string connectionString, out string errorMessage)
        {
            throw new NotImplementedException();
        }

        public IPersistenceConfigurer GetDatabaseConfiguration(IConnectionStringSettings connectionStringSettings)
        {
            throw new NotImplementedException();
        }

        public Func<IDbConnection> GetConnectionFactory(string connectionString)
        {
            throw new NotImplementedException();
        }

        public UpgradeEngineBuilder GetUpgradeEngineBuilder(string connectionString, string schema)
        {
            throw new NotImplementedException();
        }
    }
}
