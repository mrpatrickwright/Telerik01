using System;
using System.Collections.Generic;

namespace Telerik01.Models
{
    public partial class MembershipType
    {
        public MembershipType()
        {
            Account = new HashSet<Account>();
        }

        public int Id { get; set; }
        public string MembershipName { get; set; }

        public virtual ICollection<Account> Account { get; set; }
    }
}
