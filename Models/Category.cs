using System;
using System.Collections.Generic;

namespace Telerik01.Models
{
    public partial class Category
    {
        public Category()
        {
            ActivityCategory = new HashSet<ActivityCategory>();
        }

        public int Id { get; set; }
        public string CategoryName { get; set; }
        public int AccountId { get; set; }

        public virtual Account Account { get; set; }
        public virtual ICollection<ActivityCategory> ActivityCategory { get; set; }
    }
}
