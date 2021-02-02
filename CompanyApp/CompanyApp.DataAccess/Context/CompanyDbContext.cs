using CompanyApp.Domain.Enums;
using CompanyApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace CompanyApp.DataAccess.Context
{
    public class CompanyDbContext : DbContext
    {
        public CompanyDbContext() { }
        public CompanyDbContext(DbContextOptions options)
            : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<SupplyActivity> SupplyActivities { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SupplyActivity>()
                .HasKey(sa => new { sa.StoreId, sa.WarehouseId, sa.ProductId });

            modelBuilder.Entity<Store>()
                .HasMany(s => s.SupplyActivities)
                .WithOne(sa => sa.Store)
                .HasForeignKey(sa => sa.StoreId);

            modelBuilder.Entity<Warehouse>()
                .HasMany(w => w.SupplyActivities)
                .WithOne(sa => sa.Warehouse)
                .HasForeignKey(sa => sa.WarehouseId);

            modelBuilder.Entity<Product>()
                .HasMany(p => p.SupplyActivities)
                .WithOne(sa => sa.Product)
                .HasForeignKey(sa => sa.ProductId);

            Seed(modelBuilder);
        }

        public void Seed(ModelBuilder modelBuilder)
        {
            var stores = new[]
            {
                new Store()
                {
                    Id = 1,
                    Name = "Store1",
                    PhoneNumber = "070/111-111",
                    Address = "StoreAddress 1",
                    Manager = "John Doe",
                    Type = StoreType.Shop,
                    Size = 55
                },
                new Store()
                {
                    Id = 2,
                    Name = "Store2",
                    PhoneNumber = "070/222-222",
                    Address = "StoreAddress 2",
                    Manager = "John Doe",
                    Type = StoreType.Supermarket,
                    Size = 77.7
                },
                new Store()
                {
                    Id = 3,
                    Name = "Store3",
                    PhoneNumber = "070/333-333",
                    Address = "StoreAddress 3",
                    Manager = "John Doe",
                    Type = StoreType.Discount,
                    Size = 55.5
                }
            };
            var warehouses = new[]
            {
                new Warehouse()
                {
                    Id = 1,
                    Name = "Warehouse1",
                    PhoneNumber = "071/111-111",
                },
                new Warehouse()
                {
                    Id = 2,
                    Name = "Warehouse2",
                    PhoneNumber = "071/121-212",
                }
            };
            var products = new[]
            {
                new Product() { Id = 1, Name = "Product1" },
                new Product() { Id = 2, Name = "Product2" },
                new Product() { Id = 3, Name = "Product3" },
                new Product() { Id = 4, Name = "Product4" },
                new Product() { Id = 5, Name = "Product5" }
            };
            var supplyActivities = new[]
            {
                new SupplyActivity(){Id = 1, StoreId = 1, WarehouseId = 1, ProductId = 1, Quantity = 1, DateOfSupply = DateTime.Now},
                new SupplyActivity(){Id = 2, StoreId = 1, WarehouseId = 1, ProductId = 2, Quantity = 3, DateOfSupply = DateTime.Now},
                new SupplyActivity(){Id = 3, StoreId = 1, WarehouseId = 1, ProductId = 3, Quantity = 5, DateOfSupply = DateTime.Now},
                new SupplyActivity(){Id = 4, StoreId = 2, WarehouseId = 2, ProductId = 4, Quantity = 3, DateOfSupply = DateTime.Now},
                new SupplyActivity(){Id = 5, StoreId = 3, WarehouseId = 2, ProductId = 4, Quantity = 4, DateOfSupply = DateTime.Now},
                new SupplyActivity(){Id = 6, StoreId = 3, WarehouseId = 1, ProductId = 5, Quantity = 7, DateOfSupply = DateTime.Now},
                new SupplyActivity(){Id = 7, StoreId = 3, WarehouseId = 1, ProductId = 2, Quantity = 11, DateOfSupply = DateTime.Now},
            };

            modelBuilder.Entity<Store>()
                .HasData(stores[0], stores[1], stores[2]);
            modelBuilder.Entity<Warehouse>()
                .HasData(warehouses[0], warehouses[1]);
            modelBuilder.Entity<Product>()
                .HasData(products[0], products[1], products[2], products[3], products[4]);
            modelBuilder.Entity<SupplyActivity>()
                .HasData(supplyActivities[0], supplyActivities[1], supplyActivities[2], 
                    supplyActivities[3], supplyActivities[4], supplyActivities[5], supplyActivities[6]);
        }
    }
}
