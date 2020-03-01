using System;
using System.Collections.Generic;

namespace Telerik01.Models
{
    public partial class Account
    {
        public Account()
        {
            Activity = new HashSet<Activity>();
            ActivityCountType = new HashSet<ActivityCountType>();
            Block = new HashSet<Block>();
            BlockActivity = new HashSet<BlockActivity>();
            BodyPart = new HashSet<BodyPart>();
            Category = new HashSet<Category>();
            ClassPlan = new HashSet<ClassPlan>();
            ClassPlanType = new HashSet<ClassPlanType>();
            Tag = new HashSet<Tag>();
            UserAccount = new HashSet<UserAccount>();
        }

        public int Id { get; set; }
        public int MembershipTypeId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? ExpireDate { get; set; }
        public bool IsTrial { get; set; }
        public DateTime? TrialEndDate { get; set; }
        public int? StripeAccountId { get; set; }

        public virtual MembershipType MembershipType { get; set; }
        public virtual StripeAccount StripeAccount { get; set; }
        public virtual ICollection<Activity> Activity { get; set; }
        public virtual ICollection<ActivityCountType> ActivityCountType { get; set; }
        public virtual ICollection<Block> Block { get; set; }
        public virtual ICollection<BlockActivity> BlockActivity { get; set; }
        public virtual ICollection<BodyPart> BodyPart { get; set; }
        public virtual ICollection<Category> Category { get; set; }
        public virtual ICollection<ClassPlan> ClassPlan { get; set; }
        public virtual ICollection<ClassPlanType> ClassPlanType { get; set; }
        public virtual ICollection<Tag> Tag { get; set; }
        public virtual ICollection<UserAccount> UserAccount { get; set; }
    }
}
