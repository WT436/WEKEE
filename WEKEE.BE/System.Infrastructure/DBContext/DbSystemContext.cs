using System;
using System.Domain.Entitys;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace System.Infrastructure.DBContext
{
    public partial class DbSystemContext : DbContext
    {
        public DbSystemContext()
        {
        }

        public DbSystemContext(DbContextOptions<DbSystemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ExceptionLog> ExceptionLogs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                                               .SetBasePath(Directory.GetCurrentDirectory())
                                               .AddJsonFile("appsettings.json")
                                               .Build();
                var connectionString = configuration.GetConnectionString("DbSystemDbContextStr");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<ExceptionLog>(entity =>
            {
                entity.ToTable("ExceptionLog");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AccountCreate).HasColumnName("account_create");

                entity.Property(e => e.DateRaised)
                    .HasColumnType("datetime")
                    .HasColumnName("dateRaised")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("UpdatedAt")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ErrorMessage)
                    .HasMaxLength(3000)
                    .HasColumnName("errorMessage");

                entity.Property(e => e.ErrorTrace).HasColumnName("errorTrace");

                entity.Property(e => e.IpAccount)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ip_account");

                entity.Property(e => e.IsFix)
                    .HasColumnName("isFix")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Level)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("level");

                entity.Property(e => e.ServerError)
                    .HasMaxLength(100)
                    .HasColumnName("serverError");

                entity.Property(e => e.UpdateCount).HasColumnName("updateCount");
            });

            OnModelCreatingPartial(modelBuilder);
        }


        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
