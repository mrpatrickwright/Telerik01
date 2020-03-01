using System;
using System.Collections.Generic;

namespace Telerik01.Models
{
    public partial class Tag
    {
        public Tag()
        {
            ActivityTag = new HashSet<ActivityTag>();
        }

        public int Id { get; set; }
        public string TagName { get; set; }
        public int AccountId { get; set; }

        public virtual Account Account { get; set; }
        public virtual ICollection<ActivityTag> ActivityTag { get; set; }
    }
}
