using System;
using System.Collections.Generic;

namespace Telerik01.Models
{
    public partial class ActivityTag
    {
        public int Id { get; set; }
        public int ActivityId { get; set; }
        public int TagId { get; set; }

        public virtual Activity Activity { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
