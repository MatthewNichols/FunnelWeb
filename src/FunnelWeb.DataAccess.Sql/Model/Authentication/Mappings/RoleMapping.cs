using System;
using FluentNHibernate.Mapping;
using FunnelWeb.Domain.Model.Authentication;

namespace FunnelWeb.DataAccess.Sql.Model.Authentication.Mappings
{
    public class RoleMapping : ClassMap<Role>
    {
        public RoleMapping()
        {
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Name);

            HasManyToMany(x => x.Users)
                .AsBag()
                .Table("UserRoles")
                .ParentKeyColumn("RoleId")
                .ChildKeyColumn("UserId")
                .Cascade.All();
        }
    }
}
