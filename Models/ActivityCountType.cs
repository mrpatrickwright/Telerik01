using System;
using System.Collections.Generic;

namespace Telerik01.Models
{
    public partial class ActivityCountType
    {
        public int Id { get; set; }
        public string ActivityCountTypeDescription { get; set; }
        public int AccountId { get; set; }

        public virtual Account Account { get; set; }
    }
}
