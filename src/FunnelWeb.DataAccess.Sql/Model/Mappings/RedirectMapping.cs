using FluentNHibernate.Mapping;
using FunnelWeb.Domain.Model;

namespace FunnelWeb.DataAccess.Sql.Model.Mappings
{
    public class RedirectMapping : ClassMap<Redirect>
    {
        public RedirectMapping()
        {
            Id(x => x.Id);
            Map(x => x.From, "[From]");
            Map(x => x.To, "[To]");
        }
    }
}
