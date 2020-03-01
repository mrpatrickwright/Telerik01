using System;
using System.Collections.Generic;

namespace Telerik01.Models
{
    public partial class Activity
    {
        public Activity()
        {
            ActivityBodyPart = new HashSet<ActivityBodyPart>();
            ActivityCategory = new HashSet<ActivityCategory>();
            ActivityClassPlanType = new HashSet<ActivityClassPlanType>();
            ActivityTag = new HashSet<ActivityTag>();
            BlockActivityActivity = new HashSet<BlockActivity>();
            BlockActivityAlternateActivity = new HashSet<BlockActivity>();
        }

        public int Id { get; set; }
        public int AccountId { get; set; }
        public string ActivityName { get; set; }
        public string Notes { get; set; }

        public virtual Account Account { get; set; }
        public virtual ICollection<ActivityBodyPart> ActivityBodyPart { get; set; }
        public virtual ICollection<ActivityCategory> ActivityCategory { get; set; }
        public virtual ICollection<ActivityClassPlanType> ActivityClassPlanType { get; set; }
        public virtual ICollection<ActivityTag> ActivityTag { get; set; }
        public virtual ICollection<BlockActivity> BlockActivityActivity { get; set; }
        public virtual ICollection<BlockActivity> BlockActivityAlternateActivity { get; set; }
    }
}
