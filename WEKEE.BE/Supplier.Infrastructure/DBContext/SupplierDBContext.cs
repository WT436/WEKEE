using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Supplier.Domain.Shared.Entitys;

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
        public virtual DbSet<Domain.Shared.Entitys.Supplier> Suppliers { get; set; }
        public virtual DbSet<SupplierCertificate> SupplierCertificates { get; set; }
        public virtual DbSet<SupplierMapping> SupplierMappings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-94A3VHK;Database=SupplierDB;Trusted_Connection=True;");
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
                    .HasConstraintName("FK__CarouselS__shopS__31EC6D26");
            });

            modelBuilder.Entity<RepositoryCertificate>(entity =>
            {
                entity.ToTable("RepositoryCertificate");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
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
                    .HasConstraintName("FK__ShopSuppl__suppl__2E1BDC42");
            });

            modelBuilder.Entity<Domain.Shared.Entitys.Supplier>(entity =>
            {
                entity.ToTable("Supplier");

                entity.Property(e => e.Adress).HasMaxLength(300);

                entity.Property(e => e.CompanyVat).HasMaxLength(1000);

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.HaskPass)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Hosts).HasMaxLength(1000);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsEnabled).HasDefaultValueSql("((0))");

                entity.Property(e => e.LinkShop)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.NameShop)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.NumberPhone).HasColumnType("numeric(14, 0)");

                entity.Property(e => e.PassWordShop)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Url).HasMaxLength(400);
            });

            modelBuilder.Entity<SupplierCertificate>(entity =>
            {
                entity.ToTable("SupplierCertificate");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
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
                    .HasConstraintName("FK__SupplierC__idCer__3D5E1FD2");

                entity.HasOne(d => d.IdSupperNavigation)
                    .WithMany(p => p.SupplierCertificates)
                    .HasForeignKey(d => d.IdSupper)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SupplierC__idSup__3C69FB99");
            });

            modelBuilder.Entity<SupplierMapping>(entity =>
            {
                entity.ToTable("SupplierMapping");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IsBoss).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.SupplierMappings)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SupplierM__Suppl__29572725");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
