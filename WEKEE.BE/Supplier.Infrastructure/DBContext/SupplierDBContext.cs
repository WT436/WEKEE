using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using Supplier.Domain.Entitys;

#nullable disable

namespace Supplier.Infrastructure.DBContext
{
    public partial class SupplierDBContext : DbContext
    {
        public SupplierDBContext()
        {
        }

        public SupplierDBContext(DbContextOptions<SupplierDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CarouselSupplier> CarouselSuppliers { get; set; }
        public virtual DbSet<RepositoryCertificate> RepositoryCertificates { get; set; }
        public virtual DbSet<ShopSupplier> ShopSuppliers { get; set; }
        public virtual DbSet<Domain.Entitys.Supplier> Suppliers { get; set; }
        public virtual DbSet<SupplierCertificate> SupplierCertificates { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                                               .SetBasePath(Directory.GetCurrentDirectory())
                                               .AddJsonFile("appsettings.json")
                                               .Build();
                var connectionString = configuration.GetConnectionString("SupplierDBContextStr");
                optionsBuilder.UseSqlServer(connectionString)
                    ;
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<CarouselSupplier>(entity =>
            {
                entity.ToTable("CarouselSupplier");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.CarouselImage)
                    .IsUnicode(false)
                    .HasColumnName("carouselImage");

                entity.Property(e => e.IsEnabled)
                    .HasColumnName("isEnabled")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Link)
                    .HasMaxLength(300)
                    .HasColumnName("link");

                entity.Property(e => e.Position).HasColumnName("position");

                entity.Property(e => e.ShopSupplier).HasColumnName("shopSupplier");

                entity.Property(e => e.Title)
                    .HasMaxLength(300)
                    .HasColumnName("title");

                entity.HasOne(d => d.ShopSupplierNavigation)
                    .WithMany(p => p.CarouselSuppliers)
                    .HasForeignKey(d => d.ShopSupplier)
                    .HasConstraintName("FK__CarouselS__shopS__2E1BDC42");
            });

            modelBuilder.Entity<RepositoryCertificate>(entity =>
            {
                entity.ToTable("repositoryCertificate");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DateCreate)
                    .HasColumnType("datetime")
                    .HasColumnName("dateCreate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Descrpition)
                    .HasMaxLength(50)
                    .HasColumnName("descrpition");

                entity.Property(e => e.HtmlCertificate)
                    .IsRequired()
                    .HasColumnName("htmlCertificate");

                entity.Property(e => e.ImageCertificate)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("imageCertificate");

                entity.Property(e => e.IsEnabled)
                    .HasColumnName("isEnabled")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("title");
            });

            modelBuilder.Entity<ShopSupplier>(entity =>
            {
                entity.ToTable("ShopSupplier");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Background)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("background");

                entity.Property(e => e.Descrpition)
                    .HasMaxLength(500)
                    .HasColumnName("descrpition");

                entity.Property(e => e.Follow).HasColumnName("follow");

                entity.Property(e => e.Logo)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("logo");

                entity.Property(e => e.Seo).HasColumnName("seo");

                entity.Property(e => e.Supplier).HasColumnName("supplier");

                entity.HasOne(d => d.SupplierNavigation)
                    .WithMany(p => p.ShopSuppliers)
                    .HasForeignKey(d => d.Supplier)
                    .HasConstraintName("FK__ShopSuppl__suppl__2A4B4B5E");
            });

            modelBuilder.Entity<Domain.Entitys.Supplier>(entity =>
            {
                entity.ToTable("Supplier");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Adress)
                    .IsRequired()
                    .HasMaxLength(300)
                    .HasColumnName("adress");

                entity.Property(e => e.DateCreate)
                    .HasColumnType("datetime")
                    .HasColumnName("dateCreate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.IsEnabled).HasColumnName("isEnabled");

                entity.Property(e => e.LinkShop)
                    .IsRequired()
                    .HasMaxLength(300)
                    .HasColumnName("linkShop");

                entity.Property(e => e.NameShop)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("nameShop");

                entity.Property(e => e.NumberPhone)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("number_Phone");

                entity.Property(e => e.PassWordShop)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("passWordShop");

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

                entity.Property(e => e.UseAccount).HasColumnName("use_account");
            });

            modelBuilder.Entity<SupplierCertificate>(entity =>
            {
                entity.ToTable("supplierCertificate");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DateCreate)
                    .HasColumnType("datetime")
                    .HasColumnName("dateCreate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdCertificate).HasColumnName("idCertificate");

                entity.Property(e => e.IdSupper).HasColumnName("idSupper");

                entity.Property(e => e.IsEnabled)
                    .HasColumnName("isEnabled")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IsLevel).HasColumnName("isLevel");

                entity.HasOne(d => d.IdCertificateNavigation)
                    .WithMany(p => p.SupplierCertificates)
                    .HasForeignKey(d => d.IdCertificate)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__supplierC__idCer__398D8EEE");

                entity.HasOne(d => d.IdSupperNavigation)
                    .WithMany(p => p.SupplierCertificates)
                    .HasForeignKey(d => d.IdSupper)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__supplierC__idSup__38996AB5");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
