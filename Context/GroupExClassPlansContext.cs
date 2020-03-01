using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Telerik01.Models;

namespace Telerik01.Context
{
    public partial class GroupExClassPlansContext : DbContext
    {
        public GroupExClassPlansContext()
        {
        }

        public GroupExClassPlansContext(DbContextOptions<GroupExClassPlansContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<Activity> Activity { get; set; }
        public virtual DbSet<ActivityBodyPart> ActivityBodyPart { get; set; }
        public virtual DbSet<ActivityCategory> ActivityCategory { get; set; }
        public virtual DbSet<ActivityClassPlanType> ActivityClassPlanType { get; set; }
        public virtual DbSet<ActivityCountType> ActivityCountType { get; set; }
        public virtual DbSet<ActivityTag> ActivityTag { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Block> Block { get; set; }
        public virtual DbSet<BlockActivity> BlockActivity { get; set; }
        public virtual DbSet<BodyPart> BodyPart { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<ClassPlan> ClassPlan { get; set; }
        public virtual DbSet<ClassPlanType> ClassPlanType { get; set; }
        public virtual DbSet<Clients> Clients { get; set; }
        public virtual DbSet<MembershipType> MembershipType { get; set; }
        public virtual DbSet<RefreshTokens> RefreshTokens { get; set; }
        public virtual DbSet<StripeAccount> StripeAccount { get; set; }
        public virtual DbSet<Tag> Tag { get; set; }
        public virtual DbSet<UnitOfMeasure> UnitOfMeasure { get; set; }
        public virtual DbSet<UserAccount> UserAccount { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(local);Database=GroupExClassPlans;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.ExpireDate).HasColumnType("datetime");

                entity.Property(e => e.TrialEndDate).HasColumnType("datetime");

                entity.HasOne(d => d.MembershipType)
                    .WithMany(p => p.Account)
                    .HasForeignKey(d => d.MembershipTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Account_MembershipType");

                entity.HasOne(d => d.StripeAccount)
                    .WithMany(p => p.Account)
                    .HasForeignKey(d => d.StripeAccountId)
                    .HasConstraintName("FK_Account_StripeAccount");
            });

            modelBuilder.Entity<Activity>(entity =>
            {
                entity.Property(e => e.ActivityName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Notes).IsUnicode(false);

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Activity)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Activity_Account");
            });

            modelBuilder.Entity<ActivityBodyPart>(entity =>
            {
                entity.HasOne(d => d.Activity)
                    .WithMany(p => p.ActivityBodyPart)
                    .HasForeignKey(d => d.ActivityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ActivityBodyPart_Activity");

                entity.HasOne(d => d.BodyPart)
                    .WithMany(p => p.ActivityBodyPart)
                    .HasForeignKey(d => d.BodyPartId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ActivityBodyPart_BodyPart");
            });

            modelBuilder.Entity<ActivityCategory>(entity =>
            {
                entity.HasOne(d => d.Activity)
                    .WithMany(p => p.ActivityCategory)
                    .HasForeignKey(d => d.ActivityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ActivityCategory_Activity");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.ActivityCategory)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ActivityCategory_Category");
            });

            modelBuilder.Entity<ActivityClassPlanType>(entity =>
            {
                entity.HasOne(d => d.Activity)
                    .WithMany(p => p.ActivityClassPlanType)
                    .HasForeignKey(d => d.ActivityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ActivityClassPlanType_Activity");

                entity.HasOne(d => d.ClassPlanType)
                    .WithMany(p => p.ActivityClassPlanType)
                    .HasForeignKey(d => d.ClassPlanTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ActivityClassPlanType_ClassPlanType");
            });

            modelBuilder.Entity<ActivityCountType>(entity =>
            {
                entity.Property(e => e.ActivityCountTypeDescription)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.ActivityCountType)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ActivityCountType_Account");
            });

            modelBuilder.Entity<ActivityTag>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Activity)
                    .WithMany(p => p.ActivityTag)
                    .HasForeignKey(d => d.ActivityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ActivityTag_Activity");

                entity.HasOne(d => d.Tag)
                    .WithMany(p => p.ActivityTag)
                    .HasForeignKey(d => d.TagId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ActivityTag_Tag");
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("RoleNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id).HasMaxLength(128);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserId");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey, e.UserId })
                    .HasName("PK_dbo.AspNetUserLogins");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserId");

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId })
                    .HasName("PK_dbo.AspNetUserRoles");

                entity.HasIndex(e => e.RoleId)
                    .HasName("IX_RoleId");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserId");

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.Property(e => e.RoleId).HasMaxLength(128);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.UserName)
                    .HasName("UserNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id).HasMaxLength(128);

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.LockoutEndDateUtc).HasColumnType("datetime");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<Block>(entity =>
            {
                entity.Property(e => e.BlockName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Music)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Notes)
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Block)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Block_Account");

                entity.HasOne(d => d.ClassPlan)
                    .WithMany(p => p.Block)
                    .HasForeignKey(d => d.ClassPlanId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Block_ClassPlan");

                entity.HasOne(d => d.UnitOfMeasure)
                    .WithMany(p => p.Block)
                    .HasForeignKey(d => d.UnitOfMeasureId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Block_UnitOfMeasure");
            });

            modelBuilder.Entity<BlockActivity>(entity =>
            {
                entity.Property(e => e.Notes).IsUnicode(false);

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.BlockActivity)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BlockActivity_Account");

                entity.HasOne(d => d.Activity)
                    .WithMany(p => p.BlockActivityActivity)
                    .HasForeignKey(d => d.ActivityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BlockActivity_Activity");

                entity.HasOne(d => d.AlternateActivity)
                    .WithMany(p => p.BlockActivityAlternateActivity)
                    .HasForeignKey(d => d.AlternateActivityId)
                    .HasConstraintName("FK_BlockActivity_Activity1");

                entity.HasOne(d => d.Block)
                    .WithMany(p => p.BlockActivity)
                    .HasForeignKey(d => d.BlockId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BlockActivity_Block");
            });

            modelBuilder.Entity<BodyPart>(entity =>
            {
                entity.Property(e => e.BodyPartName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.BodyPart)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BodyPart_Account");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Category)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Category_Account");
            });

            modelBuilder.Entity<ClassPlan>(entity =>
            {
                entity.Property(e => e.ClassPlanName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Music)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.ClassPlan)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClassPlan_Account");

                entity.HasOne(d => d.ClassPlanType)
                    .WithMany(p => p.ClassPlan)
                    .HasForeignKey(d => d.ClassPlanTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClassPlan_ClassPlanType");
            });

            modelBuilder.Entity<ClassPlanType>(entity =>
            {
                entity.HasIndex(e => new { e.ClassPlanTypeName, e.AccountId })
                    .HasName("IX_ClassPlan")
                    .IsUnique();

                entity.Property(e => e.ClassPlanTypeName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.ClassPlanType)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClassPlanType_Account");
            });

            modelBuilder.Entity<Clients>(entity =>
            {
                entity.Property(e => e.Id).HasMaxLength(128);

                entity.Property(e => e.AllowedOrigin).HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Secret).IsRequired();
            });

            modelBuilder.Entity<MembershipType>(entity =>
            {
                entity.Property(e => e.MembershipName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RefreshTokens>(entity =>
            {
                entity.Property(e => e.Id).HasMaxLength(128);

                entity.Property(e => e.ClientId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ExpiresUtc).HasColumnType("datetime");

                entity.Property(e => e.IssuedUtc).HasColumnType("datetime");

                entity.Property(e => e.ProtectedTicket).IsRequired();

                entity.Property(e => e.Subject)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<StripeAccount>(entity =>
            {
                entity.Property(e => e.MembershipPlan)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StripeId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.Property(e => e.TagName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Tag)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tag_Account");
            });

            modelBuilder.Entity<UnitOfMeasure>(entity =>
            {
                entity.Property(e => e.UnitOfMeasureName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserAccount>(entity =>
            {
                entity.Property(e => e.AccountRole)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.AspnetUserId)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.WizardStep).HasMaxLength(50);

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.UserAccount)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserAccount_Account");

                entity.HasOne(d => d.AspnetUser)
                    .WithMany(p => p.UserAccount)
                    .HasForeignKey(d => d.AspnetUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserAccount_AspNetUsers");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
