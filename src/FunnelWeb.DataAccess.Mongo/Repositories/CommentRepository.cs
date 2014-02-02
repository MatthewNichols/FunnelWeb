using System.Collections.Generic;
using FunnelWeb.Domain.Interfaces.Repositories;
using FunnelWeb.Domain.Model;

namespace FunnelWeb.DataAccess.Mongo.Repositories
{
    public class CommentRepository : BaseRepository<Comment>, ICommentRepository
    {
        #region Implementation of ICommentRepository

        public IEnumerable<Comment> GetSpam()
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}