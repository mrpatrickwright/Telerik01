using System;
using System.Collections.Generic;

namespace Telerik01.Models
{
    public partial class ActivityClassPlanType
    {
        public int Id { get; set; }
        public int ActivityId { get; set; }
        public int ClassPlanTypeId { get; set; }

        public virtual Activity Activity { get; set; }
        public virtual ClassPlanType ClassPlanType { get; set; }
    }
}
