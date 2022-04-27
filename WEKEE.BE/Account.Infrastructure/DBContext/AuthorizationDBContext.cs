using System;
using Account.Domain.Shared.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Account.Infrastructure.DBContext
{
    public partial class AuthorizationDBContext : DbContext
    {
        public AuthorizationDBContext()
        {
        }

        public AuthorizationDBContext(DbContextOptions<AuthorizationDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Atomic> Atomics { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<HistoryTable> HistoryTables { get; set; }
        public virtual DbSet<InfomationUser> InfomationUsers { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<PermissionAssignment> PermissionAssignments { get; set; }
        public virtual DbSet<ProcessUser> ProcessUsers { get; set; }
        public virtual DbSet<ReourceAssignment> ReourceAssignments { get; set; }
        public virtual DbSet<Resource> Resources { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<SubjectAssignment> SubjectAssignments { get; set; }
        public virtual DbSet<SubjectGroup> SubjectGroups { get; set; }
        public virtual DbSet<UserIp> UserIps { get; set; }
        public virtual DbSet<UserPassword> UserPasswords { get; set; }
        public virtual DbSet<UserProfile> UserProfiles { get; set; }
        public virtual DbSet<UserStatus> UserStatuses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=AuthorizationDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("Address");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AccountId).HasColumnName("accountId");

                entity.Property(e => e.AdressLine1)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("adressLine1");

                entity.Property(e => e.AdressLine2)
                    .HasMaxLength(256)
                    .HasColumnName("adressLine2");

                entity.Property(e => e.AdressLine3)
                    .HasMaxLength(256)
                    .HasColumnName("adressLine3");

                entity.Property(e => e.CreatedOnUtc).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("description");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("isActive")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedOnUtc).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK__Address__account__5070F446");
            });

            modelBuilder.Entity<Atomic>(entity =>
            {
                entity.ToTable("Atomic");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedOnUtc).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("isActive")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.TypesRsc).HasColumnName("typesRsc");

                entity.Property(e => e.UpdatedOnUtc).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.ToTable("Group");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedOnUtc).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.GroupType)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("groupType");

                entity.Property(e => e.Introduce).HasColumnName("introduce");

                entity.Property(e => e.LinkedPages)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("linkedPages");

                entity.Property(e => e.MembershipApproval)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("membershipApproval");

                entity.Property(e => e.NameGroup)
                    .IsRequired()
                    .HasMaxLength(300)
                    .HasColumnName("nameGroup");

                entity.Property(e => e.PostApproval)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("postApproval");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Tags)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("tags");

                entity.Property(e => e.UpdatedOnUtc).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<HistoryTable>(entity =>
            {
                entity.ToTable("HistoryTable");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ActionRecord).HasColumnName("action_record");

                entity.Property(e => e.CreatedOnUtc).HasDefaultValueSql("(getdate())");

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

                entity.Property(e => e.UpdatedOnUtc).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<InfomationUser>(entity =>
            {
                entity.ToTable("InfomationUser");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AccountId).HasColumnName("accountId");

                entity.Property(e => e.Coordinates)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("coordinates");

                entity.Property(e => e.CreatedOnUtc).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("description");

                entity.Property(e => e.FirsName)
                    .HasMaxLength(255)
                    .HasColumnName("firsName");

                entity.Property(e => e.Gender).HasColumnName("gender");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("isActive")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LastName)
                    .HasMaxLength(255)
                    .HasColumnName("lastName");

                entity.Property(e => e.Picture)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("picture");

                entity.Property(e => e.UpdatedOnUtc).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.InfomationUsers)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK__Infomatio__accou__5812160E");
            });

            modelBuilder.Entity<Permission>(entity =>
            {
                entity.ToTable("Permission");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedOnUtc).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("isActive")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LevelPermition).HasColumnName("levelPermition");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.PermissionId).HasColumnName("permissionId");

                entity.Property(e => e.UpdatedOnUtc).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Atomic)
                    .WithMany(p => p.Permissions)
                    .HasForeignKey(d => d.AtomicId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Permissio__Atomi__17036CC0");

                entity.HasOne(d => d.PermissionNavigation)
                    .WithMany(p => p.InversePermissionNavigation)
                    .HasForeignKey(d => d.PermissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Permissio__permi__19DFD96B");
            });

            modelBuilder.Entity<PermissionAssignment>(entity =>
            {
                entity.ToTable("PermissionAssignment");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedOnUtc).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("isActive")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.PermissionId).HasColumnName("permissionId");

                entity.Property(e => e.RoleId).HasColumnName("roleId");

                entity.Property(e => e.UpdatedOnUtc).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.PermissionAssignments)
                    .HasForeignKey(d => d.PermissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Permissio__permi__2180FB33");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.PermissionAssignments)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Permissio__roleI__208CD6FA");
            });

            modelBuilder.Entity<ProcessUser>(entity =>
            {
                entity.ToTable("ProcessUser");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AccountId).HasColumnName("accountId");

                entity.Property(e => e.CreatedOnUtc).HasDefaultValueSql("(getdate())");

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
                    .HasColumnName("ipUser");

                entity.Property(e => e.IsStatus).HasColumnName("isStatus");

                entity.Property(e => e.UpdatedOnUtc).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.ProcessUsers)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK__ProcessUs__accou__5EBF139D");
            });

            modelBuilder.Entity<ReourceAssignment>(entity =>
            {
                entity.ToTable("ReourceAssignment");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedOnUtc).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("isActive")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.PermissionId).HasColumnName("permissionId");

                entity.Property(e => e.ResourceId).HasColumnName("resourceId");

                entity.Property(e => e.UpdatedOnUtc).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.ReourceAssignments)
                    .HasForeignKey(d => d.PermissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ReourceAs__permi__29221CFB");

                entity.HasOne(d => d.Resource)
                    .WithMany(p => p.ReourceAssignments)
                    .HasForeignKey(d => d.ResourceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ReourceAs__resou__282DF8C2");
            });

            modelBuilder.Entity<Resource>(entity =>
            {
                entity.ToTable("Resource");

                entity.HasIndex(e => e.Name, "UQ__Resource__72E12F1B4FE40F47")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedOnUtc).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("isActive")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(300)
                    .HasColumnName("name");

                entity.Property(e => e.TypesRsc).HasColumnName("typesRsc");

                entity.Property(e => e.UpdatedOnUtc).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedOnUtc).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("isActive")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IsDelete).HasColumnName("isDelete");

                entity.Property(e => e.LevelRole).HasColumnName("levelRole");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.RoleManageId).HasColumnName("roleManageId");

                entity.Property(e => e.UpdatedOnUtc).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.RoleManage)
                    .WithMany(p => p.InverseRoleManage)
                    .HasForeignKey(d => d.RoleManageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Role__roleManage__7B5B524B");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.ToTable("Subject");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedOnUtc).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.GorupId).HasColumnName("gorupId");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("isActive")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedOnUtc).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.Gorup)
                    .WithMany(p => p.Subjects)
                    .HasForeignKey(d => d.GorupId)
                    .HasConstraintName("FK__Subject__gorupId__6C190EBB");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Subjects)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Subject__userId__6B24EA82");
            });

            modelBuilder.Entity<SubjectAssignment>(entity =>
            {
                entity.ToTable("SubjectAssignment");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedOnUtc).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("isActive")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.RoleId).HasColumnName("roleId");

                entity.Property(e => e.SubjectId).HasColumnName("subjectId");

                entity.Property(e => e.UpdatedOnUtc).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.SubjectAssignments)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SubjectAs__roleI__02FC7413");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.SubjectAssignments)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SubjectAs__subje__03F0984C");
            });

            modelBuilder.Entity<SubjectGroup>(entity =>
            {
                entity.ToTable("SubjectGroup");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedOnUtc).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.GorupId).HasColumnName("gorupId");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(300)
                    .HasColumnName("name");

                entity.Property(e => e.SubjectId).HasColumnName("subjectId");

                entity.Property(e => e.UpdatedOnUtc).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Gorup)
                    .WithMany(p => p.SubjectGroups)
                    .HasForeignKey(d => d.GorupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SubjectGr__gorup__72C60C4A");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.SubjectGroups)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SubjectGr__subje__73BA3083");
            });

            modelBuilder.Entity<UserIp>(entity =>
            {
                entity.ToTable("UserIp");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AccountId).HasColumnName("accountId");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("city");

                entity.Property(e => e.CountryCode)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("countryCode");

                entity.Property(e => e.CountryName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("countryName");

                entity.Property(e => e.CreatedOnUtc).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Ipv4)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ipv4");

                entity.Property(e => e.Ipv6)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ipv6");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.IsDelete).HasColumnName("isDelete");

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

                entity.Property(e => e.UpdateAcount).HasColumnName("updateAcount");

                entity.Property(e => e.UpdatedOnUtc).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserAgent)
                    .HasMaxLength(300)
                    .HasColumnName("userAgent");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.UserIps)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserIp__accountI__46E78A0C");
            });

            modelBuilder.Entity<UserPassword>(entity =>
            {
                entity.ToTable("UserPassword");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.CreatedOnUtc).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.IsDelete).HasColumnName("isDelete");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordHashAlgorithm)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordSalt)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedOnUtc).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.UserPasswords)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserPassw__Accou__3F466844");
            });

            modelBuilder.Entity<UserProfile>(entity =>
            {
                entity.ToTable("UserProfile");

                entity.HasIndex(e => e.UserName, "UQ__UserProf__66DCF95C0ED86600")
                    .IsUnique();

                entity.HasIndex(e => e.Email, "UQ__UserProf__AB6E6164660272BA")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedOnUtc).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(254)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.FacebookId)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("facebookId");

                entity.Property(e => e.GoogleId)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("googleId");

                entity.Property(e => e.IsAcceptTerm).HasColumnName("is_accept_term");

                entity.Property(e => e.IsOnline)
                    .IsRequired()
                    .HasColumnName("isOnline")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IsStatus).HasColumnName("isStatus");

                entity.Property(e => e.LockAccountTime)
                    .HasColumnType("datetime")
                    .HasColumnName("lockAccountTime");

                entity.Property(e => e.LoginFallNumber).HasColumnName("loginFallNumber");

                entity.Property(e => e.NumberPhone)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("numberPhone");

                entity.Property(e => e.TimeZone)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("time_zone");

                entity.Property(e => e.UpdatedOnUtc).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("userName");

                entity.Property(e => e.ZaloId)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("zaloId");
            });

            modelBuilder.Entity<UserStatus>(entity =>
            {
                entity.ToTable("UserStatus");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AccountId).HasColumnName("accountId");

                entity.Property(e => e.Code)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("code");

                entity.Property(e => e.CreatedOnUtc).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.IsDelete).HasColumnName("isDelete");

                entity.Property(e => e.ReminderExpire).HasColumnName("reminderExpire");

                entity.Property(e => e.ReminderToken)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("reminderToken");

                entity.Property(e => e.StatusId).HasColumnName("statusId");

                entity.Property(e => e.UpdateCount).HasColumnName("updateCount");

                entity.Property(e => e.UpdatedOnUtc).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.UserStatuses)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK__UserStatu__accou__36B12243");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
