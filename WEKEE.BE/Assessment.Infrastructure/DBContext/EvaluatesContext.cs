using System;
using System.IO;
using Assessment.Domain.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace Assessment.Infrastructure.DBContext
{
    public partial class EvaluatesContext : DbContext
    {
        public EvaluatesContext()
        {
        }

        public EvaluatesContext(DbContextOptions<EvaluatesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<EvaluatesProduct> EvaluatesProducts { get; set; }
        public virtual DbSet<ImageEvaluatesProduct> ImageEvaluatesProducts { get; set; }
        public virtual DbSet<LikeEvaluatesProduct> LikeEvaluatesProducts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                                               .SetBasePath(Directory.GetCurrentDirectory())
                                               .AddJsonFile("appsettings.json")
                                               .Build();
                var connectionString = configuration.GetConnectionString("EvaluatesContextStr");
                optionsBuilder.UseSqlServer(connectionString)
                    ;
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<EvaluatesProduct>(entity =>
            {
                entity.ToTable("EvaluatesProduct");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Account).HasColumnName("account");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasColumnName("content");

                entity.Property(e => e.DateCreate)
                    .HasColumnType("datetime")
                    .HasColumnName("dateCreate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateUpdate)
                    .HasColumnType("datetime")
                    .HasColumnName("dateUpdate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdEvaluatesProduct).HasColumnName("idEvaluatesProduct");

                entity.Property(e => e.LevelEvaluates).HasColumnName("levelEvaluates");

                entity.Property(e => e.PinFeeling).HasColumnName("pinFeeling");

                entity.Property(e => e.Product).HasColumnName("product");

                entity.Property(e => e.StarNumber)
                    .HasColumnName("starNumber")
                    .HasDefaultValueSql("((3))");

                entity.Property(e => e.TagAccount)
                    .HasMaxLength(30)
                    .HasColumnName("tagAccount");

                entity.HasOne(d => d.IdEvaluatesProductNavigation)
                    .WithMany(p => p.InverseIdEvaluatesProductNavigation)
                    .HasForeignKey(d => d.IdEvaluatesProduct)
                    .HasConstraintName("FK__Evaluates__idEva__276EDEB3");
            });

            modelBuilder.Entity<ImageEvaluatesProduct>(entity =>
            {
                entity.ToTable("ImageEvaluatesProduct");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Alt)
                    .IsRequired()
                    .HasMaxLength(300)
                    .HasColumnName("alt");

                entity.Property(e => e.DateCreate)
                    .HasColumnType("datetime")
                    .HasColumnName("dateCreate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateUpdate)
                    .HasColumnType("datetime")
                    .HasColumnName("dateUpdate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Folder)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("folder");

                entity.Property(e => e.IdEvaluatesProduct).HasColumnName("idEvaluatesProduct");

                entity.Property(e => e.ImageRoot).HasColumnName("imageRoot");

                entity.Property(e => e.IsEnabled).HasColumnName("isEnabled");

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

                entity.Property(e => e.TypesImage).HasColumnName("typesImage");

                entity.HasOne(d => d.ImageRootNavigation)
                    .WithMany(p => p.InverseImageRootNavigation)
                    .HasForeignKey(d => d.ImageRoot)
                    .HasConstraintName("FK__ImageEval__image__300424B4");
            });

            modelBuilder.Entity<LikeEvaluatesProduct>(entity =>
            {
                entity.ToTable("LikeEvaluatesProduct");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Account).HasColumnName("account");

                entity.Property(e => e.DateCreate)
                    .HasColumnType("datetime")
                    .HasColumnName("dateCreate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateUpdate)
                    .HasColumnType("datetime")
                    .HasColumnName("dateUpdate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdEvaluates).HasColumnName("idEvaluates");

                entity.Property(e => e.Isdislike).HasColumnName("isdislike");

                entity.Property(e => e.Islike).HasColumnName("islike");

                entity.Property(e => e.LevelEvaluates).HasColumnName("levelEvaluates");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder); 
    }
}
