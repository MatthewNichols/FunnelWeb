using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson;

namespace FunnelWeb.Domain.Model
{
    public abstract class AggregateRoot
    {
        public ObjectId Id { get; set; }
    }
}
