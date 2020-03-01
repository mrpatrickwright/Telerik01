using System;
using System.Collections.Generic;

namespace Telerik01.Models
{
    public partial class ActivityBodyPart
    {
        public int Id { get; set; }
        public int ActivityId { get; set; }
        public int BodyPartId { get; set; }

        public virtual Activity Activity { get; set; }
        public virtual BodyPart BodyPart { get; set; }
    }
}
