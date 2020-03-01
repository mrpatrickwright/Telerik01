using System;
using System.Collections.Generic;

namespace Telerik01.Models
{
    public partial class StripeAccount
    {
        public StripeAccount()
        {
            Account = new HashSet<Account>();
        }

        public int Id { get; set; }
        public string StripeId { get; set; }
        public string MembershipPlan { get; set; }
        public bool Active { get; set; }
        public int Quantity { get; set; }

        public virtual ICollection<Account> Account { get; set; }
    }
}
