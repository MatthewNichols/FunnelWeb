using FluentNHibernate.Mapping;
using FunnelWeb.Domain.Model;

namespace FunnelWeb.DataAccess.Sql.Model.Mappings
{
    public class TagMapping : ClassMap<Tag>
    {
        public TagMapping()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            HasManyToMany(x => x.Entries)
                .Table("TagItem")
                .ParentKeyColumn("TagId")
                .ChildKeyColumn("EntryId")
                .Inverse()
                .LazyLoad();
        }
    }
}
