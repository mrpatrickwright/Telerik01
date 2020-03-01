using System;
using System.Collections.Generic;

namespace Telerik01.Models
{
    public partial class ActivityCategory
    {
        public int Id { get; set; }
        public int ActivityId { get; set; }
        public int CategoryId { get; set; }

        public virtual Activity Activity { get; set; }
        public virtual Category Category { get; set; }
    }
}
