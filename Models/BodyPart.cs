using System;
using System.Collections.Generic;

namespace Telerik01.Models
{
    public partial class BodyPart
    {
        public BodyPart()
        {
            ActivityBodyPart = new HashSet<ActivityBodyPart>();
        }

        public int Id { get; set; }
        public string BodyPartName { get; set; }
        public int AccountId { get; set; }

        public virtual Account Account { get; set; }
        public virtual ICollection<ActivityBodyPart> ActivityBodyPart { get; set; }
    }
}
