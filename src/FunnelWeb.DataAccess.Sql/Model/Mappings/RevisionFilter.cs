using System;
using System.Linq;
using FluentNHibernate.Mapping;

namespace FunnelWeb.DataAccess.Sql.Model.Mappings
{
    public class RevisionFilter : FilterDefinition
    {
        public RevisionFilter()
        {
            WithName("RevisionFilter")
                .AddParameter("revisionNumber", NHibernate.NHibernateUtil.Int32);
        }
    }
}
