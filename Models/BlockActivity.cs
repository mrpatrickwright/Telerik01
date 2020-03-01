using System;
using System.Collections.Generic;

namespace Telerik01.Models
{
    public partial class BlockActivity
    {
        public int Id { get; set; }
        public int BlockId { get; set; }
        public int ActivityId { get; set; }
        public int? AlternateActivityId { get; set; }
        public int? UnitCount { get; set; }
        public int SortOrder { get; set; }
        public int AccountId { get; set; }
        public string Notes { get; set; }
        public int? Reps { get; set; }
        public int? Rest { get; set; }
        public int? TransitionTime { get; set; }
        public int TimesExecuted { get; set; }

        public virtual Account Account { get; set; }
        public virtual Activity Activity { get; set; }
        public virtual Activity AlternateActivity { get; set; }
        public virtual Block Block { get; set; }
    }
}
