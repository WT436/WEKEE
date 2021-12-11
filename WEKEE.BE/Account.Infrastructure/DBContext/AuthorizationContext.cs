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
        public virtual DbSet<HistoryTable> HistoryTables { get; set; }
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
        public virtual DbSet<UserAccountIp> UserAccountIps { get; set; }
        public virtual DbSet<UserAccountStatus> UserAccountStatuses { get; set; }
        public virtual DbSet<UserLogin> UserLogins { get; set; }
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

                entity.Property(e => e.CreateBy).HasColumnName("create_by");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
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

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.ActionBaseNavigation)
                    .WithMany(p => p.InverseActionBaseNavigation)
                    .HasForeignKey(d => d.ActionBase)
                    .HasConstraintName("FK__Action__action_b__1EA48E88");

                entity.HasOne(d => d.Atomic)
                    .WithMany(p => p.Actions)
                    .HasForeignKey(d => d.AtomicId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Action__atomic_i__1DB06A4F");
            });

            modelBuilder.Entity<ActionAssignment>(entity =>
            {
                entity.ToTable("ActionAssignment");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ActionId).HasColumnName("action_id");

                entity.Property(e => e.CreateBy).HasColumnName("create_by");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("is_active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.PermissionId).HasColumnName("permission_id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Action)
                    .WithMany(p => p.ActionAssignments)
                    .HasForeignKey(d => d.ActionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ActionAss__actio__25518C17");

                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.ActionAssignments)
                    .HasForeignKey(d => d.PermissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ActionAss__permi__245D67DE");
            });

            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("Address");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

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

                entity.Property(e => e.CreateBy).HasColumnName("create_by");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("description");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("is_active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK__Address__account__49C3F6B7");
            });

            modelBuilder.Entity<Atomic>(entity =>
            {
                entity.ToTable("Atomic");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreateBy).HasColumnName("create_by");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
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

                entity.Property(e => e.TypesRsc)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("types_rsc");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<AuthorizationConstraint>(entity =>
            {
                entity.ToTable("AuthorizationConstraint");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreateBy).HasColumnName("create_by");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("is_active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(300)
                    .HasColumnName("name");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<ConstraintAssignment>(entity =>
            {
                entity.ToTable("ConstraintAssignment");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AuthorizationConstraintId).HasColumnName("authorizationConstraint_id");

                entity.Property(e => e.CreateBy).HasColumnName("create_by");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("is_active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.PermissionId).HasColumnName("permission_id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.AuthorizationConstraint)
                    .WithMany(p => p.ConstraintAssignments)
                    .HasForeignKey(d => d.AuthorizationConstraintId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Constrain__autho__0D7A0286");

                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.ConstraintAssignments)
                    .HasForeignKey(d => d.PermissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Constrain__permi__0C85DE4D");
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.ToTable("Group");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreateBy).HasColumnName("create_by");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.GroupType)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("group_type");

                entity.Property(e => e.Introduce).HasColumnName("introduce");

                entity.Property(e => e.LinkedPages)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("linked_pages");

                entity.Property(e => e.MembershipApproval)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("membership_approval");

                entity.Property(e => e.NameGroup)
                    .IsRequired()
                    .HasMaxLength(300)
                    .HasColumnName("name_group");

                entity.Property(e => e.PostApproval)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("post_approval");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Tags)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("tags");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<HistoryTable>(entity =>
            {
                entity.ToTable("HistoryTable");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ActionRecord).HasColumnName("action_record");

                entity.Property(e => e.CreateBy).HasColumnName("create_by");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DataNew)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("data_new");

                entity.Property(e => e.DataOld)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("data_old");

                entity.Property(e => e.IdRecord).HasColumnName("id_record");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<InfomationUser>(entity =>
            {
                entity.ToTable("InfomationUser");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.Coordinates)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("coordinates");

                entity.Property(e => e.CreateBy).HasColumnName("create_by");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("description");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(255)
                    .HasColumnName("first_name");

                entity.Property(e => e.FullName)
                    .HasMaxLength(255)
                    .HasColumnName("full_name");

                entity.Property(e => e.Gender).HasColumnName("gender");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("is_active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LastName)
                    .HasMaxLength(255)
                    .HasColumnName("last_name");

                entity.Property(e => e.Picture)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("picture");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.InfomationUsers)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK__Infomatio__accou__5070F446");
            });

            modelBuilder.Entity<Permission>(entity =>
            {
                entity.ToTable("Permission");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreateBy).HasColumnName("create_by");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
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

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<PermissionAssignment>(entity =>
            {
                entity.ToTable("PermissionAssignment");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreateBy).HasColumnName("create_by");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("is_active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.PermissionId).HasColumnName("permission_id");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.PermissionAssignments)
                    .HasForeignKey(d => d.PermissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Permissio__permi__02084FDA");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.PermissionAssignments)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Permissio__role___01142BA1");
            });

            modelBuilder.Entity<ProcessUser>(entity =>
            {
                entity.ToTable("ProcessUser");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.CreateBy).HasColumnName("create_by");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
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

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.ProcessUsers)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK__ProcessUs__accou__5629CD9C");
            });

            modelBuilder.Entity<Resource>(entity =>
            {
                entity.ToTable("Resource");

                entity.HasIndex(e => e.Name, "UQ__Resource__72E12F1B27295D07")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreateBy).HasColumnName("create_by");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
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
                    .HasColumnName("types_rsc");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<ResourceAction>(entity =>
            {
                entity.ToTable("ResourceAction");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ActionId).HasColumnName("action_id");

                entity.Property(e => e.CreateBy).HasColumnName("create_by");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("is_active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ResourceId).HasColumnName("resource_id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Action)
                    .WithMany(p => p.ResourceActions)
                    .HasForeignKey(d => d.ActionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ResourceA__actio__2BFE89A6");

                entity.HasOne(d => d.Resource)
                    .WithMany(p => p.ResourceActions)
                    .HasForeignKey(d => d.ResourceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ResourceA__resou__2B0A656D");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreateBy).HasColumnName("create_by");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
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

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.RoleNavigation)
                    .WithMany(p => p.InverseRoleNavigation)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Role__role_id__6EF57B66");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.ToTable("Subject");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreateBy).HasColumnName("create_by");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.GorupId).HasColumnName("gorup_id");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("is_active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Gorup)
                    .WithMany(p => p.Subjects)
                    .HasForeignKey(d => d.GorupId)
                    .HasConstraintName("FK__Subject__gorup_i__619B8048");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Subjects)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Subject__user_id__60A75C0F");
            });

            modelBuilder.Entity<SubjectAssignment>(entity =>
            {
                entity.ToTable("SubjectAssignment");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreateBy).HasColumnName("create_by");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("is_active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.SubjectId).HasColumnName("subject_id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.SubjectAssignments)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SubjectAs__role___75A278F5");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.SubjectAssignments)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SubjectAs__subje__76969D2E");
            });

            modelBuilder.Entity<SubjectGroup>(entity =>
            {
                entity.ToTable("SubjectGroup");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreateBy).HasColumnName("create_by");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.GorupId).HasColumnName("gorup_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(300)
                    .HasColumnName("name");

                entity.Property(e => e.SubjectId).HasColumnName("subject_id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Gorup)
                    .WithMany(p => p.SubjectGroups)
                    .HasForeignKey(d => d.GorupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SubjectGr__gorup__6754599E");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.SubjectGroups)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SubjectGr__subje__68487DD7");
            });

            modelBuilder.Entity<UserAccountIp>(entity =>
            {
                entity.ToTable("UserAccountIp");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("city");

                entity.Property(e => e.CountryCode)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("country_code");

                entity.Property(e => e.CountryName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("country_name");

                entity.Property(e => e.CreateBy).HasColumnName("create_by");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Ipv4)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ipv4");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.IsDelete).HasColumnName("is_delete");

                entity.Property(e => e.Latitude)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("latitude");

                entity.Property(e => e.Longitude)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("longitude");

                entity.Property(e => e.Postal)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("postal");

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("state");

                entity.Property(e => e.UpdateAcount).HasColumnName("update_acount");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserAgent)
                    .HasMaxLength(300)
                    .HasColumnName("user_agent");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.UserAccountIps)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserAccou__accou__412EB0B6");
            });

            modelBuilder.Entity<UserAccountStatus>(entity =>
            {
                entity.ToTable("UserAccountStatus");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.Code)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("code");

                entity.Property(e => e.CreateBy).HasColumnName("create_by");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.IsDelete).HasColumnName("is_delete");

                entity.Property(e => e.ReminderExpire).HasColumnName("reminder_expire");

                entity.Property(e => e.ReminderToken)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("reminder_token");

                entity.Property(e => e.StatusId).HasColumnName("status_id");

                entity.Property(e => e.UpdateCount).HasColumnName("update_count");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.UserAccountStatuses)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK__UserAccou__accou__2E1BDC42");
            });

            modelBuilder.Entity<UserLogin>(entity =>
            {
                entity.ToTable("UserLogin");

                entity.HasIndex(e => e.UserName, "UQ__UserLogi__7C9273C499656B4F")
                    .IsUnique();

                entity.HasIndex(e => e.Email, "UQ__UserLogi__AB6E6164BA059B79")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.CreateBy).HasColumnName("create_by");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
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
                    .HasColumnName("number_phone");

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

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("user_name");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.UserLogin)
                    .HasForeignKey<UserLogin>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserLogin__id__37A5467C");
            });

            modelBuilder.Entity<UserProfile>(entity =>
            {
                entity.ToTable("UserProfile");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreateBy).HasColumnName("create_by");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FacebookId)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("facebook_id");

                entity.Property(e => e.GoogleId)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("google_id");

                entity.Property(e => e.IsAcceptTerm).HasColumnName("is_accept_term");

                entity.Property(e => e.TimeZone)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("time_zone");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("(getdate())");

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
