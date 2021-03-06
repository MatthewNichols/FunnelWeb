﻿using FluentNHibernate.Mapping;
using FunnelWeb.Domain.Model;

namespace FunnelWeb.DataAccess.Sql.Model.Mappings
{
    public class TaskStateMapping : ClassMap<TaskState>
    {
        public TaskStateMapping()
        {
            Id(x => x.Id);
            Map(x => x.TaskName);
            Map(x => x.Status);
            Map(x => x.Started);
            Map(x => x.ProgressEstimate);
            Map(x => x.OutputLog);
            Map(x => x.Updated);
            Map(x => x.Arguments);
        }
    }
}
