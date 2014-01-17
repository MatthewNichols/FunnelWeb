using FluentNHibernate.Mapping;
using FunnelWeb.Core.Model.Mappings.UserTypes;

namespace FunnelWeb.Core.Model.Mappings
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
