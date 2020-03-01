using System;
using System.Collections.Generic;

namespace Telerik01.Models
{
    public partial class Block
    {
        public Block()
        {
            BlockActivity = new HashSet<BlockActivity>();
        }

        public int Id { get; set; }
        public string BlockName { get; set; }
        public int ClassPlanId { get; set; }
        public int AccountId { get; set; }
        public int SortOrder { get; set; }
        public string Notes { get; set; }
        public int UnitOfMeasureId { get; set; }
        public int TimesExecuted { get; set; }
        public string Music { get; set; }

        public virtual Account Account { get; set; }
        public virtual ClassPlan ClassPlan { get; set; }
        public virtual UnitOfMeasure UnitOfMeasure { get; set; }
        public virtual ICollection<BlockActivity> BlockActivity { get; set; }
    }
}
