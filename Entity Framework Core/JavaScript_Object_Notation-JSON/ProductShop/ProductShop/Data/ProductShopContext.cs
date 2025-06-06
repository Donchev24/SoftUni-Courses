﻿namespace ProductShop.Data
{
    using Microsoft.EntityFrameworkCore;
    using ProductShop.Models;
    public class ProductShopContext : DbContext
    {
        public ProductShopContext()
        {

        }

        public ProductShopContext(DbContextOptions options)
            : base(options)
        {

        }

        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<CategoryProduct> CategoriesProducts { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }

            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryProduct>(entity =>
            {
                entity.HasKey(x => new { x.CategoryId, x.ProductId });
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasMany(x => x.ProductsBought)
                      .WithOne(x => x.Buyer)
                      .HasForeignKey(x => x.BuyerId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(x => x.ProductsSold)
                      .WithOne(x => x.Seller)
                      .HasForeignKey(x => x.SellerId)
                      .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
