using System;
using System.Collections.Generic;

namespace Telerik01.Models
{
    public partial class ClassPlan
    {
        public ClassPlan()
        {
            Block = new HashSet<Block>();
        }

        public int Id { get; set; }
        public string ClassPlanName { get; set; }
        public int ClassPlanTypeId { get; set; }
        public int AccountId { get; set; }
        public string Music { get; set; }

        public virtual Account Account { get; set; }
        public virtual ClassPlanType ClassPlanType { get; set; }
        public virtual ICollection<Block> Block { get; set; }
    }
}
