using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Product.Domain.Entitys;

#nullable disable

namespace Product.Infrastructure.DBContext
{
    public partial class ProductDBContext : DbContext
    {
        public ProductDBContext()
        {
        }

        public ProductDBContext(DbContextOptions<ProductDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CategoryProduct> CategoryProducts { get; set; }
        public virtual DbSet<ImageProduct> ImageProducts { get; set; }
        public virtual DbSet<PredefinedProductAttributeValue> PredefinedProductAttributeValues { get; set; }
        public virtual DbSet<Product.Domain.Entitys.Product> Products { get; set; }
        public virtual DbSet<ProductAttribute> ProductAttributes { get; set; }
        public virtual DbSet<ProductAttributeValue> ProductAttributeValues { get; set; }
        public virtual DbSet<ProductCategoryMapping> ProductCategoryMappings { get; set; }
        public virtual DbSet<ProductPictureMapping> ProductPictureMappings { get; set; }
        public virtual DbSet<ProductProductAttributeMapping> ProductProductAttributeMappings { get; set; }
        public virtual DbSet<ProductProductTagMapping> ProductProductTagMappings { get; set; }
        public virtual DbSet<ProductSpecificationAttributeMapping> ProductSpecificationAttributeMappings { get; set; }
        public virtual DbSet<ProductTag> ProductTags { get; set; }
        public virtual DbSet<ProductWarehouseInventory> ProductWarehouseInventories { get; set; }
        public virtual DbSet<Seo> Seos { get; set; }
        public virtual DbSet<SpecificationAttribute> SpecificationAttributes { get; set; }
        public virtual DbSet<SpecificationAttributeGroup> SpecificationAttributeGroups { get; set; }
        public virtual DbSet<SpecificationAttributeOption> SpecificationAttributeOptions { get; set; }
        public virtual DbSet<StockQuantityHistory> StockQuantityHistories { get; set; }
        public virtual DbSet<Warehouse> Warehouses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=ProductDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<CategoryProduct>(entity =>
            {
                entity.ToTable("CategoryProduct");

                entity.HasIndex(e => e.NameCategory, "UQ__Category__431B4023F03F6407")
                    .IsUnique();

                entity.HasIndex(e => e.UrlCategory, "UQ__Category__B1978B95FB6CAB51")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CategoryMain).HasColumnName("categoryMain");

                entity.Property(e => e.CreatedOnUtc).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IconCategory)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("iconCategory");

                entity.Property(e => e.IsEnabled).HasColumnName("isEnabled");

                entity.Property(e => e.LevelCategory)
                    .HasColumnName("levelCategory")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.NameCategory)
                    .IsRequired()
                    .HasMaxLength(300)
                    .HasColumnName("nameCategory");

                entity.Property(e => e.NumberOrder).HasColumnName("numberOrder");

                entity.Property(e => e.UpdatedOnUtc).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UrlCategory)
                    .IsRequired()
                    .HasMaxLength(300)
                    .HasColumnName("urlCategory");
            });

            modelBuilder.Entity<ImageProduct>(entity =>
            {
                entity.ToTable("ImageProduct");

                entity.Property(e => e.Folder)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MimeType)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.SeoFilename).HasMaxLength(300);

                entity.Property(e => e.Size)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.ImageRootNavigation)
                    .WithMany(p => p.InverseImageRootNavigation)
                    .HasForeignKey(d => d.ImageRoot)
                    .HasConstraintName("FK__ImageProd__Image__3E52440B");

                entity.HasOne(d => d.ProductNavigation)
                    .WithMany(p => p.ImageProducts)
                    .HasForeignKey(d => d.Product)
                    .HasConstraintName("FK__ImageProd__Produ__3F466844");
            });

            modelBuilder.Entity<PredefinedProductAttributeValue>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("PredefinedProductAttributeValue");

                entity.Property(e => e.Cost).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(400);

                entity.Property(e => e.PriceAdjustment).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.WeightAdjustment).HasColumnType("decimal(18, 4)");

                entity.HasOne(d => d.ProductAttribute)
                    .WithMany()
                    .HasForeignKey(d => d.ProductAttributeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Predefine__Produ__534D60F1");
            });

            modelBuilder.Entity<Product.Domain.Entitys.Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AdditionalShippingCharge).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.AllowedQuantities).HasMaxLength(1000);

                entity.Property(e => e.Fragile)
                    .HasColumnName("fragile")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Gtin).HasMaxLength(400);

                entity.Property(e => e.Height).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.Length).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.ManufacturerPartNumber).HasMaxLength(400);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.Origin)
                    .HasMaxLength(300)
                    .HasColumnName("origin");

                entity.Property(e => e.OverriddenGiftCardAmount).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.ProductAlbum)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("productAlbum")
                    .HasDefaultValueSql("('highlights')");

                entity.Property(e => e.RequiredProductIds).HasMaxLength(1000);

                entity.Property(e => e.Seo).HasColumnName("seo");

                entity.Property(e => e.Sku).HasMaxLength(400);

                entity.Property(e => e.Supplier).HasColumnName("supplier");

                entity.Property(e => e.Weight).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.Width).HasColumnType("decimal(18, 4)");

                entity.HasOne(d => d.SeoNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.Seo)
                    .HasConstraintName("FK__Product__seo__34C8D9D1");
            });

            modelBuilder.Entity<ProductAttribute>(entity =>
            {
                entity.ToTable("ProductAttribute");

                entity.Property(e => e.CreatedOnUtc).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsDelete).HasColumnName("isDelete");

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.UpdatedOnUtc).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<ProductAttributeValue>(entity =>
            {
                entity.ToTable("ProductAttributeValue");

                entity.Property(e => e.ColorSquaresRgb).HasMaxLength(100);

                entity.Property(e => e.Cost).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(400);

                entity.Property(e => e.PriceAdjustment).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.WeightAdjustment).HasColumnType("decimal(18, 4)");
            });

            modelBuilder.Entity<ProductCategoryMapping>(entity =>
            {
                entity.ToTable("Product_Category_Mapping");

                entity.Property(e => e.CreatedOnUtc).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UpdatedOnUtc).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.ProductCategoryMappings)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Product_C__Categ__37A5467C");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductCategoryMappings)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Product_C__Produ__38996AB5");
            });

            modelBuilder.Entity<ProductPictureMapping>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Product_Picture_Mapping");

                entity.Property(e => e.CreatedOnUtc).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.IsDelete).HasColumnName("isDelete");

                entity.Property(e => e.UpdatedOnUtc).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Picture)
                    .WithMany()
                    .HasForeignKey(d => d.PictureId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Product_P__Pictu__412EB0B6");

                entity.HasOne(d => d.Product)
                    .WithMany()
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Product_P__Produ__4222D4EF");
            });

            modelBuilder.Entity<ProductProductAttributeMapping>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Product_ProductAttribute_Mapping");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.AttributeControlType)
                    .WithMany()
                    .HasForeignKey(d => d.AttributeControlTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Product_P__Attri__59063A47");

                entity.HasOne(d => d.ProductAttribute)
                    .WithMany()
                    .HasForeignKey(d => d.ProductAttributeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Product_P__Produ__571DF1D5");

                entity.HasOne(d => d.Product)
                    .WithMany()
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Product_P__Produ__5812160E");
            });

            modelBuilder.Entity<ProductProductTagMapping>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Product_ProductTag_Mapping");

                entity.Property(e => e.ProductId).HasColumnName("Product_Id");

                entity.Property(e => e.ProductTagId).HasColumnName("ProductTag_Id");

                entity.HasOne(d => d.Product)
                    .WithMany()
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Product_P__Produ__4BAC3F29");

                entity.HasOne(d => d.ProductTag)
                    .WithMany()
                    .HasForeignKey(d => d.ProductTagId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Product_P__Produ__4CA06362");
            });

            modelBuilder.Entity<ProductSpecificationAttributeMapping>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Product_SpecificationAttribute_Mapping");

                entity.Property(e => e.CustomValue).HasMaxLength(4000);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.Product)
                    .WithMany()
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Product_S__Produ__68487DD7");

                entity.HasOne(d => d.SpecificationAttributeOption)
                    .WithMany()
                    .HasForeignKey(d => d.SpecificationAttributeOptionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Product_S__Speci__693CA210");
            });

            modelBuilder.Entity<ProductTag>(entity =>
            {
                entity.ToTable("ProductTag");

                entity.Property(e => e.CreatedOnUtc).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsDelete).HasColumnName("isDelete");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(400);

                entity.Property(e => e.UpdatedOnUtc).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<ProductWarehouseInventory>(entity =>
            {
                entity.ToTable("ProductWarehouseInventory");
            });

            modelBuilder.Entity<Seo>(entity =>
            {
                entity.ToTable("Seo");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedOnUtc).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsEnabled).HasColumnName("isEnabled");

                entity.Property(e => e.IsLevel).HasColumnName("isLevel");

                entity.Property(e => e.MetaContentLanguage).HasColumnName("meta_Content_Language");

                entity.Property(e => e.MetaContentType).HasColumnName("meta_Content_Type");

                entity.Property(e => e.MetaDescription).HasColumnName("meta_Description");

                entity.Property(e => e.MetaKeywords).HasColumnName("meta_Keywords");

                entity.Property(e => e.MetaProperty).HasColumnName("meta_Property");

                entity.Property(e => e.MetaRevisitAfter).HasColumnName("meta_Revisit_After");

                entity.Property(e => e.MetaRobots)
                    .HasMaxLength(20)
                    .HasColumnName("meta_Robots");

                entity.Property(e => e.MetaTitle)
                    .HasMaxLength(70)
                    .HasColumnName("meta_title");

                entity.Property(e => e.UpdatedOnUtc).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UseAccount).HasColumnName("use_account");
            });

            modelBuilder.Entity<SpecificationAttribute>(entity =>
            {
                entity.ToTable("SpecificationAttribute");

                entity.Property(e => e.Name).IsRequired();

                entity.HasOne(d => d.SpecificationAttributeGroup)
                    .WithMany(p => p.SpecificationAttributes)
                    .HasForeignKey(d => d.SpecificationAttributeGroupId)
                    .HasConstraintName("FK__Specifica__Speci__6383C8BA");
            });

            modelBuilder.Entity<SpecificationAttributeGroup>(entity =>
            {
                entity.ToTable("SpecificationAttributeGroup");

                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<SpecificationAttributeOption>(entity =>
            {
                entity.ToTable("SpecificationAttributeOption");

                entity.Property(e => e.ColorSquaresRgb).HasMaxLength(100);

                entity.Property(e => e.Name).IsRequired();

                entity.HasOne(d => d.SpecificationAttribute)
                    .WithMany(p => p.SpecificationAttributeOptions)
                    .HasForeignKey(d => d.SpecificationAttributeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Specifica__Speci__66603565");
            });

            modelBuilder.Entity<StockQuantityHistory>(entity =>
            {
                entity.ToTable("StockQuantityHistory");
            });

            modelBuilder.Entity<Warehouse>(entity =>
            {
                entity.ToTable("Warehouse");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(400);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
