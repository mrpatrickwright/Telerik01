using System;
using System.Collections.Generic;

namespace Telerik01.Models
{
    public partial class UserAccount
    {
        public int Id { get; set; }
        public string AspnetUserId { get; set; }
        public int AccountId { get; set; }
        public string AccountRole { get; set; }
        public string WizardStep { get; set; }

        public virtual Account Account { get; set; }
        public virtual AspNetUsers AspnetUser { get; set; }
    }
}
