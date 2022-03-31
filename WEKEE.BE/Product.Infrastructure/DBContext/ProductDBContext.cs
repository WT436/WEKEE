using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Product.Domain.Shared.Entitys;

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
        public virtual DbSet<FeatureProduct> FeatureProducts { get; set; }
        public virtual DbSet<ImageProduct> ImageProducts { get; set; }
        public virtual DbSet<Product.Domain.Shared.Entitys.Product> Products { get; set; }
        public virtual DbSet<ProductAttribute> ProductAttributes { get; set; }
        public virtual DbSet<ProductAttributeMapping> ProductAttributeMappings { get; set; }
        public virtual DbSet<ProductAttributeValue> ProductAttributeValues { get; set; }
        public virtual DbSet<ProductCategoryMapping> ProductCategoryMappings { get; set; }
        public virtual DbSet<ProductPictureMapping> ProductPictureMappings { get; set; }
        public virtual DbSet<ProductProductTagMapping> ProductProductTagMappings { get; set; }
        public virtual DbSet<ProductSpecificationAttributeMapping> ProductSpecificationAttributeMappings { get; set; }
        public virtual DbSet<ProductTag> ProductTags { get; set; }
        public virtual DbSet<ProductWarehouseInventory> ProductWarehouseInventories { get; set; }
        public virtual DbSet<Seo> Seos { get; set; }
        public virtual DbSet<SpecificationAttribute> SpecificationAttributes { get; set; }
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

                entity.HasIndex(e => e.NameCategory, "UQ__Category__431B4023841ABE7A")
                    .IsUnique();

                entity.HasIndex(e => e.UrlCategory, "UQ__Category__B1978B95000926C7")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CategoryMain).HasColumnName("categoryMain");

                entity.Property(e => e.CreatedOnUtc)
                    .HasColumnName("createdOnUtc")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IconCategory).HasColumnName("iconCategory");

                entity.Property(e => e.IsEnabled).HasColumnName("isEnabled");

                entity.Property(e => e.LevelCategory)
                    .HasColumnName("levelCategory")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.NameCategory)
                    .IsRequired()
                    .HasMaxLength(300)
                    .HasColumnName("nameCategory");

                entity.Property(e => e.NumberOrder).HasColumnName("numberOrder");

                entity.Property(e => e.UpdatedOnUtc)
                    .HasColumnName("updatedOnUtc")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UrlCategory)
                    .IsRequired()
                    .HasMaxLength(300)
                    .HasColumnName("urlCategory");

                entity.HasOne(d => d.CategoryMainNavigation)
                    .WithMany(p => p.InverseCategoryMainNavigation)
                    .HasForeignKey(d => d.CategoryMain)
                    .HasConstraintName("FK__CategoryP__categ__2E1BDC42");

                entity.HasOne(d => d.IconCategoryNavigation)
                    .WithMany(p => p.CategoryProducts)
                    .HasForeignKey(d => d.IconCategory)
                    .HasConstraintName("FK__CategoryP__iconC__2B3F6F97");
            });

            modelBuilder.Entity<FeatureProduct>(entity =>
            {
                entity.ToTable("FeatureProduct");

                entity.Property(e => e.CreatedOnUtc).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.HeightAdjustment).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.LengthAdjustment).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.UpdatedOnUtc).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.WeightAdjustment).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.WidthAdjustment).HasColumnType("decimal(18, 4)");

                entity.HasOne(d => d.ImageSquaresPicture)
                    .WithMany(p => p.FeatureProductImageSquaresPictures)
                    .HasForeignKey(d => d.ImageSquaresPictureId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__FeaturePr__Image__160F4887");

                entity.HasOne(d => d.Picture)
                    .WithMany(p => p.FeatureProductPictures)
                    .HasForeignKey(d => d.PictureId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__FeaturePr__Pictu__151B244E");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.FeatureProducts)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__FeaturePr__Produ__10566F31");
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
                    .HasConstraintName("FK__ImageProd__Image__267ABA7A");
            });

            modelBuilder.Entity<Product.Domain.Shared.Entitys.Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AdditionalShippingCharge).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.CreatedOnUtc).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Fragile)
                    .HasColumnName("fragile")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Gtin).HasMaxLength(400);

                entity.Property(e => e.ManufacturerPartNumber).HasMaxLength(400);

                entity.Property(e => e.MarkAsNewEndDateTimeUtc).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.MarkAsNewStartDateTimeUtc).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.Origin)
                    .HasMaxLength(300)
                    .HasColumnName("origin");

                entity.Property(e => e.OverriddenGiftCardAmount).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.PreOrderAvailabilityStartDateTimeUtc).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ProductAlbum)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("productAlbum")
                    .HasDefaultValueSql("('highlights')");

                entity.Property(e => e.Seo).HasColumnName("seo");

                entity.Property(e => e.Sku).HasMaxLength(400);

                entity.Property(e => e.Supplier).HasColumnName("supplier");

                entity.Property(e => e.UpdatedOnUtc).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.SeoNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.Seo)
                    .HasConstraintName("FK__Product__seo__71D1E811");

                entity.HasOne(d => d.UnitAttribute)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.UnitAttributeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Product__UnitAtt__4222D4EF");
            });

            modelBuilder.Entity<ProductAttribute>(entity =>
            {
                entity.ToTable("ProductAttribute");

                entity.Property(e => e.CreatedOnUtc).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsDelete).HasColumnName("isDelete");

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.UpdatedOnUtc).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<ProductAttributeMapping>(entity =>
            {
                entity.ToTable("ProductAttributeMapping");

                entity.Property(e => e.CreatedOnUtc).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UpdatedOnUtc).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.FeatureProduct)
                    .WithMany(p => p.ProductAttributeMappings)
                    .HasForeignKey(d => d.FeatureProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ProductAt__Featu__1BC821DD");

                entity.HasOne(d => d.ProductAttributeValues)
                    .WithMany(p => p.ProductAttributeMappings)
                    .HasForeignKey(d => d.ProductAttributeValuesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ProductAt__Produ__1CBC4616");
            });

            modelBuilder.Entity<ProductAttributeValue>(entity =>
            {
                entity.ToTable("ProductAttributeValue");

                entity.Property(e => e.CreatedOnUtc).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsDelete).HasColumnName("isDelete");

                entity.Property(e => e.UpdatedOnUtc).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.KeyNavigation)
                    .WithMany(p => p.ProductAttributeValues)
                    .HasForeignKey(d => d.Key)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ProductAttr__Key__0A9D95DB");
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
                    .HasConstraintName("FK__Product_C__Categ__74AE54BC");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductCategoryMappings)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Product_C__Produ__75A278F5");
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
                    .HasConstraintName("FK__Product_P__Pictu__797309D9");

                entity.HasOne(d => d.Product)
                    .WithMany()
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Product_P__Produ__7A672E12");
            });

            modelBuilder.Entity<ProductProductTagMapping>(entity =>
            {
                entity.ToTable("Product_ProductTag_Mapping");

                entity.Property(e => e.CreatedOnUtc).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ProductId).HasColumnName("Product_Id");

                entity.Property(e => e.ProductTagId).HasColumnName("ProductTag_Id");

                entity.Property(e => e.UpdatedOnUtc).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductProductTagMappings)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Product_P__Produ__04E4BC85");

                entity.HasOne(d => d.ProductTag)
                    .WithMany(p => p.ProductProductTagMappings)
                    .HasForeignKey(d => d.ProductTagId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Product_P__Produ__05D8E0BE");
            });

            modelBuilder.Entity<ProductSpecificationAttributeMapping>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Product_SpecificationAttribute_Mapping");

                entity.Property(e => e.CreatedOnUtc).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CustomValue).HasMaxLength(4000);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.UpdatedOnUtc).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Product)
                    .WithMany()
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Product_S__Produ__2B0A656D");

                entity.HasOne(d => d.Specification)
                    .WithMany()
                    .HasForeignKey(d => d.SpecificationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Product_S__Speci__2BFE89A6");
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

                entity.Property(e => e.CreatedOnUtc)
                    .HasColumnName("createdOnUtc")
                    .HasDefaultValueSql("(getdate())");

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

                entity.Property(e => e.UpdatedOnUtc)
                    .HasColumnName("updatedOnUtc")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UseAccount).HasColumnName("use_account");
            });

            modelBuilder.Entity<SpecificationAttribute>(entity =>
            {
                entity.ToTable("SpecificationAttribute");

                entity.Property(e => e.CreatedOnUtc).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.GroupSpecification).HasMaxLength(200);

                entity.Property(e => e.Key)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("key");

                entity.Property(e => e.UpdatedOnUtc).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.CategoryProduct)
                    .WithMany(p => p.SpecificationAttributes)
                    .HasForeignKey(d => d.CategoryProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Specifica__Categ__2739D489");
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
