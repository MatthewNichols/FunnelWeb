using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FunnelWeb.Domain.Model
{
    public class Site : AggregateRoot
    {
        public Site()
        {
            settings = new List<Setting>();
        }
        /// <summary>
        /// The Host name of the site being viewed.
        /// </summary>
        /// <example>The blog http://www.bill.com/blog would have a HostName of www.bill.com</example>
        public string HostName { get; set; }

        private List<Setting> settings;

        public List<Setting> Settings
        {
            get { return settings; }
            set
            {
                if (value != null)
                {
                    settings = value;                    
                }
            }
        }


    }
}
