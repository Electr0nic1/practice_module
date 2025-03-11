using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WpfApp1.Models;

namespace WpfApp1
{
    internal class DbAppContext : DbContext
    {
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<PartnerType> PartnerTypes { get; set; }
        public DbSet<PartnerProducts> PartnerProducts { get; set; }
        public DbSet<Partner> Partners { get; set; }
        public DbSet<DeploymentHistory> DeploymentHistory { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Username=postgres;Password=root;Database=new-master-pol");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PartnerType>(entity =>
            {
                entity.ToTable("partner_type");

                entity.Property(e => e.PartnerTypeId).HasColumnName("partner_type_id");
                entity.Property(e => e.TypeName).HasColumnName("type_name");
            });

            modelBuilder.Entity<Partner>(entity =>
            {
                entity.ToTable("partner");

                entity.Property(e => e.PartnerId).HasColumnName("partner_id");
                entity.Property(e => e.CompanyName).HasColumnName("company_name");
                entity.Property(e => e.DirectorName).HasColumnName("director_name");
                entity.Property(e => e.Email).HasColumnName("email");
                entity.Property(e => e.Phone).HasColumnName("phone");
                entity.Property(e => e.RegisteredAddress).HasColumnName("registered_address");
                entity.Property(e => e.Inn).HasColumnName("INN");
                entity.Property(e => e.Rating).HasColumnName("rating");

                entity.HasOne(p => p.PartnerTypeEntity).WithMany(p => p.PartnerEntities).HasForeignKey(p => p.PartnerTypeId);
            });

            modelBuilder.Entity<DeploymentHistory>(entity =>
            {
                entity.ToTable("deployment_history");

                entity.Property(e => e.DeploymentHistoryId).HasColumnName("deployment_history_id");
                entity.Property(e => e.Date).HasColumnName("date");
                entity.Property(e => e.SalesAmount).HasColumnName("sales_amount");
                entity.Property(e => e.DiscountAmount).HasColumnName("discount_amount");

                entity.HasOne(p => p.PartnerEntity).WithMany(p => p.DeploymentHistoryEntities).HasForeignKey(p => p.PartnerId);
            });

            modelBuilder.Entity<ProductType>(entity =>
            {
                entity.ToTable("product_type");

                entity.Property(e => e.ProductTypeId).HasColumnName("product_type_id");
                entity.Property(e => e.TypeName).HasColumnName("type_name");
                entity.Property(e => e.Ratio).HasColumnName("ratio");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("product");

                entity.Property(e => e.ProductId).HasColumnName("product_id");
                entity.Property(e => e.ProductName).HasColumnName("product_name");
                entity.Property(e => e.Article).HasColumnName("article");
                entity.Property(e => e.MinCost).HasColumnName("min_cost");

                entity.HasOne(p => p.ProductTypeEntity).WithMany(p => p.ProductEntities).HasForeignKey(p => p.ProductTypeId);
            });

            modelBuilder.Entity<PartnerProducts>(entity =>
            {
                entity.ToTable("partner_products");

                entity.Property(e => e.PartnerProductsId).HasColumnName("partner_products_id");
                entity.Property(e => e.ProductAmount).HasColumnName("product_amount");
                entity.Property(e => e.SaleDate).HasColumnName("sale_date");

                entity.HasOne(p => p.PartnerEntity).WithMany(p => p.PartnerProductsEntities).HasForeignKey(p => p.PartnerId);
                entity.HasOne(p => p.ProductEntity).WithMany(p => p.PartnerProductsEntities).HasForeignKey(p => p.ProductId);
            });
        }

        public static List<>
    }
}
