﻿using System.Collections.Generic;
using System.Linq;
using FunnelWeb.Domain.Interfaces;
using NHibernate;
using NHibernate.Linq;

namespace FunnelWeb.Domain.Model.Repositories.Internal
{
    public class AdminRepository : IAdminRepository
    {
        private readonly ISession session;

        public AdminRepository(ISession session)
        {
            this.session = session;
        }

        public IQueryable<Setting> GetSettings()
        {
            return session.Query<Setting>();
        }

        public void UpdateCommentCountFor(int entryId)
        {
            var commentCount = session
                .QueryOver<Comment>()
                .Where(c => c.Entry.Id == entryId && c.Status == 1)
                .ToRowCountQuery()
                .SingleOrDefault<int>();

            var entry = session.Get<Entry>(entryId);
            entry.CommentCount = commentCount;
            session.Flush();
        }

        public void Save(IEnumerable<Setting> settings)
        {
            foreach (var setting in settings)
            {
                session.SaveOrUpdate(setting);               
            }
            session.Flush();
        }
    }
}
