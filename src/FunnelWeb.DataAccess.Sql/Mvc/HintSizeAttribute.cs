using System;

namespace FunnelWeb.DataAccess.Sql.Mvc
{
    [AttributeUsage(AttributeTargets.Property)]
    public class HintSizeAttribute : Attribute
    {
        public HintSizeAttribute(HintSize size)
        {
            Size = size;
        }

        public HintSize Size { get; private set; }
    }
}