using System;
using System.ComponentModel.DataAnnotations;
using FunnelWeb.Domain.Model.Strings;

namespace FunnelWeb.Domain.Model
{
    public class EntrySummary
    {
        public virtual int Id { get; set; }

        public virtual PageName Name { get; set; }
        public virtual string Title { get; set; }
        
        [DataType("Markdown")]
        public virtual string Summary { get; set; }

        public virtual string Status { get; set; }
        
        public virtual int CommentCount { get; set; }
        public virtual string MetaDescription { get; set; }
        [DataType("PublishedDate")]
        public virtual DateTime Published { get; set; }
        public virtual DateTime LastRevised { get; set; }

        [DataType("TagsList")]
        public virtual string TagsCommaSeparated { get; set; }

    }
}