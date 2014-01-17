using FluentNHibernate.Mapping;
using FunnelWeb.DataAccess.Sql.Model.Mappings.UserTypes;
using FunnelWeb.Domain.Model;

namespace FunnelWeb.DataAccess.Sql.Model.Mappings
{
    public class SettingMapping : ClassMap<Setting>
    {
        public SettingMapping()
        {
            Id(x => x.Id);
            Map(x => x.Description);
            Map(x => x.DisplayName);
            Map(x => x.Name).CustomType<PageNameUserType>();
            Map(x => x.Value);
        }
    }
}
