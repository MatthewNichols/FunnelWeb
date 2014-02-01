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
    public class TagRepository : BaseRepository<Tag>, ITagRepository
    {
        
        public Tag GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Tag> SearchByName(string namePart)
        {
            throw new NotImplementedException();
        }
    }
}
