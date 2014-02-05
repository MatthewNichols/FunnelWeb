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
    //This needs to be restructured
    public class TagRepository : BaseRepository<Tag>, ITagRepository
    {
        private readonly ISiteRepository siteRepository;

        #region Constructors

        public TagRepository(string connectionString, ISiteRepository siteRepository) : base(connectionString)
        {
            this.siteRepository = siteRepository;
            throw new NotImplementedException();
        }

        #endregion

        public IEnumerable<Tag> FindAll()
        {
            return siteRepository.Get(SiteContext.SiteId).Tags;
        }

        public Tag GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Tag> SearchByName(string namePart)
        {
            throw new NotImplementedException();
        }

        public override string DefaultCollectionName
        {
            get { return "Comments"; }
        }
    }
}
