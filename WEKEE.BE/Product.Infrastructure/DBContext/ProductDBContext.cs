using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
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
        public virtual DbSet<DescriptionProduct> DescriptionProducts { get; set; }
        public virtual DbSet<FeatureProduct> FeatureProducts { get; set; }
        public virtual DbSet<HighlightProduct> HighlightProducts { get; set; }
        public virtual DbSet<ImageProduct> ImageProducts { get; set; }
        public virtual DbSet<Domain.Entitys.Product> Products { get; set; }
        public virtual DbSet<Seo> Seos { get; set; }
        public virtual DbSet<SpecificationsCategory> SpecificationsCategories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                                               .SetBasePath(Directory.GetCurrentDirectory())
                                               .AddJsonFile("appsettings.json")
                                               .Build();
                var connectionString = configuration.GetConnectionString("ProductDBContextStr");
                optionsBuilder.UseSqlServer(connectionString)
                    ;
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<CategoryProduct>(entity =>
            {
                entity.ToTable("CategoryProduct");

                entity.HasIndex(e => e.NameCategory, "UQ__Category__431B4023BA211576")
                    .IsUnique();

                entity.HasIndex(e => e.UrlCategory, "UQ__Category__B1978B95F325C3A8")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CategoryMain).HasColumnName("categoryMain");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("CreatedAt")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateEnd)
                    .HasColumnType("datetime")
                    .HasColumnName("dateEnd")
                    .HasDefaultValueSql("(getdate())");

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

                entity.Property(e => e.UrlCategory)
                    .IsRequired()
                    .HasMaxLength(300)
                    .HasColumnName("urlCategory");
            });

            modelBuilder.Entity<DescriptionProduct>(entity =>
            {
                entity.ToTable("DescriptionProduct");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Blog)
                    .IsRequired()
                    .HasColumnName("blog")
                    .HasDefaultValueSql("(N'Chưa có bào viết nào về sản phẩm này ,quý khách vui lòng quay lại sau ')");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("CreatedAt")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsEnabled).HasColumnName("isEnabled");

                entity.Property(e => e.LikePost).HasColumnName("likePost");

                entity.Property(e => e.Product).HasColumnName("product");

                entity.Property(e => e.UseAccount).HasColumnName("use_account");

                entity.Property(e => e.ViewProduct).HasColumnName("viewProduct");

                entity.HasOne(d => d.ProductNavigation)
                    .WithMany(p => p.DescriptionProducts)
                    .HasForeignKey(d => d.Product)
                    .HasConstraintName("FK__Descripti__produ__5812160E");
            });

            modelBuilder.Entity<FeatureProduct>(entity =>
            {
                entity.ToTable("FeatureProduct");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("CreatedAt")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("UpdatedAt")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Guarantee).HasColumnName("guarantee");

                entity.Property(e => e.ImageProduct).HasColumnName("imageProduct");

                entity.Property(e => e.IsDefault)
                    .HasColumnName("isDefault")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IsEnabled).HasColumnName("isEnabled");

                entity.Property(e => e.IsStatus)
                    .HasColumnName("isStatus")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Key1).HasColumnName("key1");

                entity.Property(e => e.Key2).HasColumnName("key2");

                entity.Property(e => e.Mass).HasColumnName("mass");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(19, 0)")
                    .HasColumnName("price");

                entity.Property(e => e.PriceMarket)
                    .HasColumnType("decimal(19, 0)")
                    .HasColumnName("price_market");

                entity.Property(e => e.Product).HasColumnName("product");

                entity.Property(e => e.Properties1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("properties1");

                entity.Property(e => e.Properties2)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("properties2");

                entity.Property(e => e.TotalNumber).HasColumnName("total_number");

                entity.Property(e => e.Vat)
                    .HasColumnType("decimal(19, 0)")
                    .HasColumnName("vat");

                entity.Property(e => e.Volume).HasColumnName("volume");

                entity.HasOne(d => d.ImageProductNavigation)
                    .WithMany(p => p.FeatureProducts)
                    .HasForeignKey(d => d.ImageProduct)
                    .HasConstraintName("FK__FeaturePr__image__5070F446");

                entity.HasOne(d => d.Key1Navigation)
                    .WithMany(p => p.FeatureProductKey1Navigations)
                    .HasForeignKey(d => d.Key1)
                    .HasConstraintName("FK__FeaturePro__key1__48CFD27E");

                entity.HasOne(d => d.Key2Navigation)
                    .WithMany(p => p.FeatureProductKey2Navigations)
                    .HasForeignKey(d => d.Key2)
                    .HasConstraintName("FK__FeaturePro__key2__49C3F6B7");

                entity.HasOne(d => d.ProductNavigation)
                    .WithMany(p => p.FeatureProducts)
                    .HasForeignKey(d => d.Product)
                    .HasConstraintName("FK__FeaturePr__produ__4F7CD00D");
            });

            modelBuilder.Entity<HighlightProduct>(entity =>
            {
                entity.ToTable("HighlightProduct");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("CreatedAt")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("UpdatedAt")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DisplayOrder).HasColumnName("displayOrder");

                entity.Property(e => e.IsStatus)
                    .HasColumnName("isStatus")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Key).HasColumnName("key");

                entity.Property(e => e.Product).HasColumnName("product");

                entity.Property(e => e.Values)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("values");

                entity.HasOne(d => d.KeyNavigation)
                    .WithMany(p => p.HighlightProducts)
                    .HasForeignKey(d => d.Key)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__HighlightPr__key__5AEE82B9");

                entity.HasOne(d => d.ProductNavigation)
                    .WithMany(p => p.HighlightProducts)
                    .HasForeignKey(d => d.Product)
                    .HasConstraintName("FK__Highlight__produ__5EBF139D");
            });

            modelBuilder.Entity<ImageProduct>(entity =>
            {
                entity.ToTable("ImageProduct");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Alt)
                    .IsRequired()
                    .HasMaxLength(300)
                    .HasColumnName("alt");

                entity.Property(e => e.Folder)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("folder");

                entity.Property(e => e.ImageRoot).HasColumnName("imageRoot");

                entity.Property(e => e.IsCover).HasColumnName("isCover");

                entity.Property(e => e.IsEnabled).HasColumnName("isEnabled");

                entity.Property(e => e.Product).HasColumnName("product");

                entity.Property(e => e.Size)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("size");

                entity.Property(e => e.Src)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("src");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(300)
                    .HasColumnName("title");

                entity.HasOne(d => d.ImageRootNavigation)
                    .WithMany(p => p.InverseImageRootNavigation)
                    .HasForeignKey(d => d.ImageRoot)
                    .HasConstraintName("FK__ImageProd__image__4316F928");

                entity.HasOne(d => d.ProductNavigation)
                    .WithMany(p => p.ImageProducts)
                    .HasForeignKey(d => d.Product)
                    .HasConstraintName("FK__ImageProd__produ__45F365D3");
            });

            modelBuilder.Entity<Domain.Entitys.Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CategoryProduct).HasColumnName("categoryProduct");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("CreatedAt")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("UpdatedAt")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Fragile)
                    .HasColumnName("fragile")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Introduce).HasColumnName("introduce");

                entity.Property(e => e.IsEnabled).HasColumnName("isEnabled");

                entity.Property(e => e.IsStatus)
                    .HasColumnName("isStatus")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.Origin)
                    .HasMaxLength(300)
                    .HasColumnName("origin");

                entity.Property(e => e.ProductAlbum)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("productAlbum")
                    .HasDefaultValueSql("('highlights')");

                entity.Property(e => e.Seo).HasColumnName("seo");

                entity.Property(e => e.Supplier).HasColumnName("supplier");

                entity.Property(e => e.Tag)
                    .IsRequired()
                    .HasMaxLength(300)
                    .HasColumnName("tag");

                entity.Property(e => e.Trademark).HasColumnName("trademark");

                entity.Property(e => e.UnitProduct).HasColumnName("unitProduct");

                entity.HasOne(d => d.CategoryProductNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryProduct)
                    .HasConstraintName("FK__Product__categor__3E52440B");

                entity.HasOne(d => d.SeoNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.Seo)
                    .HasConstraintName("FK__Product__seo__403A8C7D");

                entity.HasOne(d => d.TrademarkNavigation)
                    .WithMany(p => p.ProductTrademarkNavigations)
                    .HasForeignKey(d => d.Trademark)
                    .HasConstraintName("FK__Product__tradema__38996AB5");

                entity.HasOne(d => d.UnitProductNavigation)
                    .WithMany(p => p.ProductUnitProductNavigations)
                    .HasForeignKey(d => d.UnitProduct)
                    .HasConstraintName("FK__Product__unitPro__36B12243");
            });

            modelBuilder.Entity<Seo>(entity =>
            {
                entity.ToTable("Seo");

                entity.Property(e => e.Id).HasColumnName("id");

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

                entity.Property(e => e.UseAccount).HasColumnName("use_account");
            });

            modelBuilder.Entity<SpecificationsCategory>(entity =>
            {
                entity.ToTable("SpecificationsCategory");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CategoryMain).HasColumnName("categoryMain");

                entity.Property(e => e.Classify).HasColumnName("classify");

                entity.Property(e => e.ClassifyValues)
                    .HasMaxLength(200)
                    .HasColumnName("classifyValues");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("CreatedAt")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsEnabled).HasColumnName("isEnabled");

                entity.Property(e => e.Key)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("key");

                entity.Property(e => e.NameShow)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("nameShow");

                entity.HasOne(d => d.CategoryMainNavigation)
                    .WithMany(p => p.SpecificationsCategories)
                    .HasForeignKey(d => d.CategoryMain)
                    .HasConstraintName("FK__Specifica__categ__300424B4");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
