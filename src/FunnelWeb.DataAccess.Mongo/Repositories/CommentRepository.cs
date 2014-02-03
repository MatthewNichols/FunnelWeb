using System.Collections.Generic;
using FunnelWeb.Domain.Interfaces.Repositories;
using FunnelWeb.Domain.Model;

namespace FunnelWeb.DataAccess.Mongo.Repositories
{
    public class CommentRepository : BaseRepository<Comment>, ICommentRepository
    {

        #region Constructors

        public CommentRepository(string connectionString) : base(connectionString)
        {}

        #endregion

        #region Implementation of ICommentRepository

        public IEnumerable<Comment> GetSpam()
        {
            throw new System.NotImplementedException();
        }

        #endregion

        public override string DefaultCollectionName
        {
            get { return "Comments"; }
        }
    }
}