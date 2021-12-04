using System;
using System.IO;
using Account.Domain.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using Action = Account.Domain.Entitys.Action;

#nullable disable

namespace Account.Infrastructure.DBContext
{
    public partial class AuthorizationContext : DbContext
    {
        public AuthorizationContext()
        {
        }

        public AuthorizationContext(DbContextOptions<AuthorizationContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Action> Actions { get; set; }
        public virtual DbSet<ActionAssignment> ActionAssignments { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Atomic> Atomics { get; set; }
        public virtual DbSet<AuthorizationConstraint> AuthorizationConstraints { get; set; }
        public virtual DbSet<ConstraintAssignment> ConstraintAssignments { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<InfomationUser> InfomationUsers { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<PermissionAssignment> PermissionAssignments { get; set; }
        public virtual DbSet<ProcessUser> ProcessUsers { get; set; }
        public virtual DbSet<Resource> Resources { get; set; }
        public virtual DbSet<ResourceAction> ResourceActions { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<SubjectAssignment> SubjectAssignments { get; set; }
        public virtual DbSet<SubjectGroup> SubjectGroups { get; set; }
        public virtual DbSet<UserAccount> UserAccounts { get; set; }
        public virtual DbSet<UserAccountIp> UserAccountIps { get; set; }
        public virtual DbSet<UserAccountStatus> UserAccountStatuses { get; set; }
        public virtual DbSet<UserProfile> UserProfiles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                                               .SetBasePath(Directory.GetCurrentDirectory())
                                               .AddJsonFile("appsettings.json")
                                               .Build();
                var connectionString = configuration.GetConnectionString("AuthorizationContextSt");
                optionsBuilder.UseSqlServer(connectionString)
                    ;
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Action>(entity =>
            {
                entity.ToTable("Action");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ActionBase).HasColumnName("action_base");

                entity.Property(e => e.AtomicId).HasColumnName("atomic_id");

                entity.Property(e => e.DateCreate)
                    .HasColumnType("datetime")
                    .HasColumnName("date_create")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("is_active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(300)
                    .HasColumnName("name");

                entity.HasOne(d => d.ActionBaseNavigation)
                    .WithMany(p => p.InverseActionBaseNavigation)
                    .HasForeignKey(d => d.ActionBase)
                    .HasConstraintName("FK__Action__action_b__797309D9");

                entity.HasOne(d => d.Atomic)
                    .WithMany(p => p.Actions)
                    .HasForeignKey(d => d.AtomicId)
                    .HasConstraintName("FK__Action__atomic_i__787EE5A0");
            });

            modelBuilder.Entity<ActionAssignment>(entity =>
            {
                entity.ToTable("ActionAssignment");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ActionId).HasColumnName("action_id");

                entity.Property(e => e.DateCreate)
                    .HasColumnType("datetime")
                    .HasColumnName("date_create")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("is_active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.PermissionId).HasColumnName("permission_id");

                entity.HasOne(d => d.Action)
                    .WithMany(p => p.ActionAssignments)
                    .HasForeignKey(d => d.ActionId)
                    .HasConstraintName("FK__ActionAss__actio__7F2BE32F");

                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.ActionAssignments)
                    .HasForeignKey(d => d.PermissionId)
                    .HasConstraintName("FK__ActionAss__permi__7E37BEF6");
            });

            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("Address");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AdressLine1)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("adress_line_1");

                entity.Property(e => e.AdressLine2)
                    .HasMaxLength(256)
                    .HasColumnName("adress_line_2");

                entity.Property(e => e.AdressLine3)
                    .HasMaxLength(256)
                    .HasColumnName("adress_line_3");

                entity.Property(e => e.DateCreate)
                    .HasColumnType("datetime")
                    .HasColumnName("date_create")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateEdit)
                    .HasColumnType("datetime")
                    .HasColumnName("date_edit")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("description");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("is_active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.UserAccountId).HasColumnName("user_account_id");

                entity.HasOne(d => d.UserAccount)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.UserAccountId)
                    .HasConstraintName("FK__Address__user_ac__0C85DE4D");
            });

            modelBuilder.Entity<Atomic>(entity =>
            {
                entity.ToTable("Atomic");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DateCreate)
                    .HasColumnType("datetime")
                    .HasColumnName("date_create")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("is_active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<AuthorizationConstraint>(entity =>
            {
                entity.ToTable("AuthorizationConstraint");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DateCreate)
                    .HasColumnType("datetime")
                    .HasColumnName("date_create")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("is_active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(300)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<ConstraintAssignment>(entity =>
            {
                entity.ToTable("ConstraintAssignment");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AuthorizationConstraintId).HasColumnName("authorizationConstraint_id");

                entity.Property(e => e.DateCreate)
                    .HasColumnType("datetime")
                    .HasColumnName("date_create")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("is_active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.PermissionId).HasColumnName("permission_id");

                entity.HasOne(d => d.AuthorizationConstraint)
                    .WithMany(p => p.ConstraintAssignments)
                    .HasForeignKey(d => d.AuthorizationConstraintId)
                    .HasConstraintName("FK__Constrain__autho__6C190EBB");

                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.ConstraintAssignments)
                    .HasForeignKey(d => d.PermissionId)
                    .HasConstraintName("FK__Constrain__permi__6B24EA82");
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.ToTable("Group");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DateCreate)
                    .HasColumnType("datetime")
                    .HasColumnName("date_create")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.GroupType)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("group_Type");

                entity.Property(e => e.Introduce).HasColumnName("introduce");

                entity.Property(e => e.LinkedPages)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("linked_Pages");

                entity.Property(e => e.MembershipApproval)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("membership_Approval");

                entity.Property(e => e.NameGroup)
                    .IsRequired()
                    .HasMaxLength(300)
                    .HasColumnName("name_group");

                entity.Property(e => e.PostApproval)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("post_Approval");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("status")
                    .HasDefaultValueSql("('PUBLIC')");

                entity.Property(e => e.Tags)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("tags");
            });

            modelBuilder.Entity<InfomationUser>(entity =>
            {
                entity.ToTable("Infomation_User");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Coordinates)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("coordinates");

                entity.Property(e => e.DateCreate)
                    .HasColumnType("datetime")
                    .HasColumnName("date_create")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateEdit)
                    .HasColumnType("datetime")
                    .HasColumnName("date_edit")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("description");

                entity.Property(e => e.Gender)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("gender");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("is_active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Picture)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("picture");

                entity.Property(e => e.UserAccountId).HasColumnName("user_account_id");

                entity.HasOne(d => d.UserAccount)
                    .WithMany(p => p.InfomationUsers)
                    .HasForeignKey(d => d.UserAccountId)
                    .HasConstraintName("FK__Infomatio__user___1332DBDC");
            });

            modelBuilder.Entity<Permission>(entity =>
            {
                entity.ToTable("Permission");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DateCreate)
                    .HasColumnType("datetime")
                    .HasColumnName("date_create")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("is_active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<PermissionAssignment>(entity =>
            {
                entity.ToTable("PermissionAssignment");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DateCreate)
                    .HasColumnType("datetime")
                    .HasColumnName("date_create")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("is_active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.PermissionId).HasColumnName("permission_id");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.PermissionAssignments)
                    .HasForeignKey(d => d.PermissionId)
                    .HasConstraintName("FK__Permissio__permi__628FA481");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.PermissionAssignments)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__Permissio__role___619B8048");
            });

            modelBuilder.Entity<ProcessUser>(entity =>
            {
                entity.ToTable("process_User");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DateCreate)
                    .HasColumnType("datetime")
                    .HasColumnName("date_create")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description");

                entity.Property(e => e.Device)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("device");

                entity.Property(e => e.IpUser)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ip_user");

                entity.Property(e => e.IsStatus).HasColumnName("is_status");

                entity.Property(e => e.UserAccountId).HasColumnName("user_account_id");

                entity.HasOne(d => d.UserAccount)
                    .WithMany(p => p.ProcessUsers)
                    .HasForeignKey(d => d.UserAccountId)
                    .HasConstraintName("FK__process_U__user___17F790F9");
            });

            modelBuilder.Entity<Resource>(entity =>
            {
                entity.ToTable("Resource");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DateCreate)
                    .HasColumnType("datetime")
                    .HasColumnName("date_create")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("is_active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(300)
                    .HasColumnName("name");

                entity.Property(e => e.TypesRsc)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("types_Rsc");
            });

            modelBuilder.Entity<ResourceAction>(entity =>
            {
                entity.ToTable("ResourceAction");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ActionId).HasColumnName("action_id");

                entity.Property(e => e.DateCreate)
                    .HasColumnType("datetime")
                    .HasColumnName("date_create")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("is_active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ResourceId).HasColumnName("resource_id");

                entity.HasOne(d => d.Action)
                    .WithMany(p => p.ResourceActions)
                    .HasForeignKey(d => d.ActionId)
                    .HasConstraintName("FK__ResourceA__actio__04E4BC85");

                entity.HasOne(d => d.Resource)
                    .WithMany(p => p.ResourceActions)
                    .HasForeignKey(d => d.ResourceId)
                    .HasConstraintName("FK__ResourceA__resou__03F0984C");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DateCreate)
                    .HasColumnType("datetime")
                    .HasColumnName("date_create")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("is_active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IsDelete).HasColumnName("is_delete");

                entity.Property(e => e.LevelRole).HasColumnName("level_role");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.HasOne(d => d.RoleNavigation)
                    .WithMany(p => p.InverseRoleNavigation)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__Role__role_id__52593CB8");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.ToTable("Subject");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DateCreate)
                    .HasColumnType("datetime")
                    .HasColumnName("date_create")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.GorupId).HasColumnName("gorup_id");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("is_active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.UserAccountId).HasColumnName("user_account_id");

                entity.HasOne(d => d.Gorup)
                    .WithMany(p => p.Subjects)
                    .HasForeignKey(d => d.GorupId)
                    .HasConstraintName("FK__Subject__gorup_i__46E78A0C");

                entity.HasOne(d => d.UserAccount)
                    .WithMany(p => p.Subjects)
                    .HasForeignKey(d => d.UserAccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Subject__user_ac__45F365D3");
            });

            modelBuilder.Entity<SubjectAssignment>(entity =>
            {
                entity.ToTable("SubjectAssignment");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DateCreate)
                    .HasColumnType("datetime")
                    .HasColumnName("date_create")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("is_active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.SubjectId).HasColumnName("subject_id");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.SubjectAssignments)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__SubjectAs__role___5812160E");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.SubjectAssignments)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK__SubjectAs__subje__59063A47");
            });

            modelBuilder.Entity<SubjectGroup>(entity =>
            {
                entity.ToTable("SubjectGroup");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DateCreate)
                    .HasColumnType("datetime")
                    .HasColumnName("date_create")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.GorupId).HasColumnName("gorup_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(300)
                    .HasColumnName("name");

                entity.Property(e => e.SubjectId).HasColumnName("subject_id");

                entity.HasOne(d => d.Gorup)
                    .WithMany(p => p.SubjectGroups)
                    .HasForeignKey(d => d.GorupId)
                    .HasConstraintName("FK__SubjectGr__gorup__4BAC3F29");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.SubjectGroups)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK__SubjectGr__subje__4CA06362");
            });

            modelBuilder.Entity<UserAccount>(entity =>
            {
                entity.HasKey(e => e.UserProfileId)
                    .HasName("PK__User_Acc__151D386EA88F53F3");

                entity.ToTable("User_Account");

                entity.HasIndex(e => e.UserName, "UQ__User_Acc__7C9273C4AB66600D")
                    .IsUnique();

                entity.HasIndex(e => e.Email, "UQ__User_Acc__AB6E6164FB7E9221")
                    .IsUnique();

                entity.Property(e => e.UserProfileId)
                    .ValueGeneratedNever()
                    .HasColumnName("user_profile_id");

                entity.Property(e => e.DateCreate)
                    .HasColumnType("datetime")
                    .HasColumnName("date_create")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(254)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.IsOnline)
                    .IsRequired()
                    .HasColumnName("is_online")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IsStatus).HasColumnName("is_status");

                entity.Property(e => e.LockAccountTime)
                    .HasColumnType("datetime")
                    .HasColumnName("lock_account_time");

                entity.Property(e => e.LoginFallNumber).HasColumnName("login_fall_number");

                entity.Property(e => e.NumberPhone)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("number_Phone");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.PasswordHashAlgorithm)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("password_hash_algorithm");

                entity.Property(e => e.PasswordSalt)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("password_salt");

                entity.Property(e => e.StatusId).HasColumnName("status_id");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("user_name");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.UserAccounts)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__User_Acco__statu__33D4B598");

                entity.HasOne(d => d.UserProfile)
                    .WithOne(p => p.UserAccount)
                    .HasForeignKey<UserAccount>(d => d.UserProfileId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__User_Acco__user___30F848ED");
            });

            modelBuilder.Entity<UserAccountIp>(entity =>
            {
                entity.ToTable("User_Account_Ip");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DateCreate)
                    .HasColumnType("datetime")
                    .HasColumnName("date_create")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateUpdate)
                    .HasColumnType("datetime")
                    .HasColumnName("date_update")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Ip)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ip");

                entity.Property(e => e.IpUserAccount).HasColumnName("ip_User_Account");

                entity.Property(e => e.IsActive).HasColumnName("is-active");

                entity.Property(e => e.IsDelete).HasColumnName("is-delete");

                entity.Property(e => e.UpdateCount).HasColumnName("update-count");

                entity.Property(e => e.UserAgent)
                    .HasMaxLength(300)
                    .HasColumnName("user-Agent");

                entity.HasOne(d => d.IpUserAccountNavigation)
                    .WithMany(p => p.UserAccountIps)
                    .HasForeignKey(d => d.IpUserAccount)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__User_Acco__ip_Us__3A81B327");
            });

            modelBuilder.Entity<UserAccountStatus>(entity =>
            {
                entity.ToTable("User_Account_Status");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Code)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("code");

                entity.Property(e => e.DateCreate)
                    .HasColumnType("datetime")
                    .HasColumnName("date_create")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateUpdate)
                    .HasColumnType("datetime")
                    .HasColumnName("date_update")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive).HasColumnName("is-active");

                entity.Property(e => e.IsDelete).HasColumnName("is-delete");

                entity.Property(e => e.ReminderExpire).HasColumnName("reminder_expire");

                entity.Property(e => e.ReminderToken)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("reminder_token");

                entity.Property(e => e.UpdateCount).HasColumnName("update-count");
            });

            modelBuilder.Entity<UserProfile>(entity =>
            {
                entity.ToTable("User_Profile");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AcceptTermOfService).HasColumnName("accept_term_of_service");

                entity.Property(e => e.DateCreate)
                    .HasColumnType("datetime")
                    .HasColumnName("date_create")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FacebookId)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("facebook_id");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(255)
                    .HasColumnName("first_name");

                entity.Property(e => e.FullName)
                    .HasMaxLength(255)
                    .HasColumnName("full_name");

                entity.Property(e => e.GoogleId)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("google_id");

                entity.Property(e => e.LastName)
                    .HasMaxLength(255)
                    .HasColumnName("last_name");

                entity.Property(e => e.TimeZone)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("time_zone");

                entity.Property(e => e.ZaloId)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("zalo_id");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
