using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FunnelWeb.Domain.Interfaces;
using FunnelWeb.Domain.Interfaces.Repositories;
using FunnelWeb.Domain.Model;

namespace FunnelWeb.DataAccess.Mongo.Repositories
{
    public class EntryRepository : BaseRepository<Entry>, IEntryRepository
    {
        public Entry GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Entry> GetQueryable()
        {
            throw new NotImplementedException();
        }
    }
}
