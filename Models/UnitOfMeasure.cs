using System;
using System.Collections.Generic;

namespace Telerik01.Models
{
    public partial class UnitOfMeasure
    {
        public UnitOfMeasure()
        {
            Block = new HashSet<Block>();
        }

        public int Id { get; set; }
        public string UnitOfMeasureName { get; set; }

        public virtual ICollection<Block> Block { get; set; }
    }
}
