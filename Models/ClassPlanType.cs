using System;
using System.Collections.Generic;

namespace Telerik01.Models
{
    public partial class ClassPlanType
    {
        public ClassPlanType()
        {
            ActivityClassPlanType = new HashSet<ActivityClassPlanType>();
            ClassPlan = new HashSet<ClassPlan>();
        }

        public int Id { get; set; }
        public string ClassPlanTypeName { get; set; }
        public int AccountId { get; set; }

        public virtual Account Account { get; set; }
        public virtual ICollection<ActivityClassPlanType> ActivityClassPlanType { get; set; }
        public virtual ICollection<ClassPlan> ClassPlan { get; set; }
    }
}
