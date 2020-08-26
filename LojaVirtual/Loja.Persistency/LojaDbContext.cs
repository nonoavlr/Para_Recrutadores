using Loja.Application;
using Loja.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace Loja.Persistency
{
    public class LojaDbContext : DbContext, IApplicationDbContext
    {
        public LojaDbContext(DbContextOptions<LojaDbContext> options) : base(options) { }
        public DbSet<Client> Client { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Item> Item { get; set; }
        public DbSet<Database> Databases { get; set; }
        public DbSet<StockSize> StockSize { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Key region
            #region
            builder.Entity<Client>().HasKey(c => c.ClientID);
            builder.Entity<Client>().Property(c => c.ClientID).ValueGeneratedOnAdd();

            builder.Entity<Product>().HasKey(c => c.ProductID);
            builder.Entity<Product>().Property(c => c.ProductID).ValueGeneratedOnAdd();


            builder.Entity<Address>().HasKey(c => c.AddressID);
            builder.Entity<Address>().Property(c => c.AddressID).ValueGeneratedOnAdd();

            builder.Entity<Order>().HasKey(c => c.OrderID);
            builder.Entity<Order>().Property(c => c.OrderID).ValueGeneratedOnAdd();

            builder.Entity<Item>().HasKey(c => c.ItemID);
            builder.Entity<Item>().Property(c => c.ItemID).ValueGeneratedOnAdd();

            builder.Entity<Database>().HasKey(c => c.DatabaseID);
            builder.Entity<Database>().Property(c => c.DatabaseID).ValueGeneratedOnAdd();

            #endregion

            //Model <Client>
            #region
            builder.Entity<Client>()
                .HasMany(c => c.Orders)
                .WithOne(c => c.Client)
                .HasForeignKey(c => c.OrderID);

            builder.Entity<Client>()
                .HasMany(c => c.Addresses)
                .WithOne(c => c.Client)
                .HasForeignKey(c => c.ClientID);

            builder.Entity<Client>()
                .HasMany(c => c.Products)
                .WithOne(c => c.Client)
                .HasForeignKey(c => c.ClientID);
            #endregion

            //Model<Order>
            #region
            builder.Entity<Order>()
                .HasMany(c => c.Items)
                .WithOne(c => c.Order)
                .HasForeignKey(c => c.OrderID);

            builder.Entity<Order>()
                .HasOne(c => c.AddressShip)
                .WithMany(c => c.Orders)
                .HasForeignKey(c => c.OrderID);
            #endregion

            //Model<Item>
            #region
            builder.Entity<Item>()
                .HasOne(c => c.Product)
                .WithMany(c => c.Items)
                .HasForeignKey(c => c.OrderID);
            #endregion

            //Model<Product>
            #region
            builder.Entity<Product>()
                .HasMany(c => c.Database)
                .WithOne(c => c.Product)
                .HasForeignKey(c => c.ProductID);

            builder.Entity<Product>()
                .HasMany(c => c.StockSize)
                .WithOne(c => c.Product)
                .HasForeignKey(c => c.ProductID);
            #endregion

            //From Start
            #region
            builder.Entity<Client>().HasData(new Client[]
                {
                    new Client(){ 
                        ClientID = 1, 
                        Name = "Admin", 
                        Email="admin@loja.com", 
                        Password="TESTE", 
                        isAdmin = true,
                        isActive = true,
                    }
                }
            );

            builder.Entity<StockSize>().HasData( new StockSize[]
                {
                    new StockSize()
                    {
                        StockSizeID = 1,
                        ProductID = 1,
                        Size = "42",
                        Stock = 9,
                    },

                    new StockSize()
                    {
                        StockSizeID = 2,
                        ProductID = 1,
                        Size = "46",
                        Stock = 3,
                    },

                    new StockSize()
                    {
                        StockSizeID = 3,
                        ProductID = 2,
                        Size = "G",
                        Stock = 12,
                    },

                    new StockSize()
                    {
                        StockSizeID = 4,
                        ProductID = 2,
                        Size = "P",
                        Stock = 5,
                    },

                    new StockSize()
                    {
                        StockSizeID = 5,
                        ProductID = 3,
                        Size = "M",
                        Stock = 5,
                    },

                    new StockSize()
                    {
                        StockSizeID = 6,
                        ProductID = 3,
                        Size = "XXG",
                        Stock = 7,
                    },

                    new StockSize()
                    {
                        StockSizeID = 7,
                        ProductID = 4,
                        Size = "38",
                        Stock = 3,
                    },

                    new StockSize()
                    {
                        StockSizeID = 8,
                        ProductID = 4,
                        Size = "43",
                        Stock = 7,
                    },

                    new StockSize()
                    {
                        StockSizeID = 9,
                        ProductID = 5,
                        Size = "41",
                        Stock = 3,
                    },

                    new StockSize()
                    {
                        StockSizeID = 10,
                        ProductID = 5,
                        Size = "37",
                        Stock = 8,
                    },

                    new StockSize()
                    {
                         StockSizeID = 11,
                         ProductID = 6,
                         Size = "44",
                         Stock = 2,
                    },

                    new StockSize()
                    {
                         StockSizeID = 12,
                         ProductID = 6,
                         Size = "38",
                         Stock = 3,
                    },

                }
            );

            builder.Entity<Product>().HasData(new Product[]
            {
                    new Product(){
                        ClientID = 1,
                        ProductID = 1,
                        Name = "Calça Jeans Strech",
                        Title = "Calça Jeans Super Pure Strech",
                        Price = 50.90,
                        Description = "Ótima lavagem, longa duração",
                        Type = "Calça",
                        Gender = "Fem",
                        isActive = true
                    },

                    new Product(){
                        ClientID = 1,
                        ProductID = 2,
                        Name = "Blusa Ultra Dry",
                        Title = "Blusa de Manga Longa",
                        Price = 70.50,
                        Description = "Impermeável",
                        Type = "Blusa",
                        Gender = "Masc",
                        isActive = true
                    },

                    new Product(){
                        ClientID = 1,
                        ProductID = 3,
                        Name = "Jaqueta Minimalista Limited Edition",
                        Title = "Jaqueta Minimalista",
                        Price = 110.10,
                        Description = "Alta Costura",
                        Type = "Calça",
                        Gender = "Both",
                        isActive = true
                    },

                    new Product(){
                        ClientID = 1,
                        ProductID = 4,
                        Name = "Tennis Vintage 90'",
                        Title = "Tennis Vintage",
                        Price = 190.50,
                        Description = "Ultra weight",
                        Type = "Calcado",
                        Gender = "Both",
                        isActive = true
                    },

                    new Product(){
                        ClientID = 1,
                        ProductID = 5,
                        Name = "Sapatilha Confort Plus",
                        Title = "Sapatilha Confortável",
                        Price = 170.90,
                        Description = "Confort Plus",
                        Type = "Calcado",
                        Gender = "Fem",
                        isActive = true
                    },

                    new Product(){
                        ClientID = 1,
                        ProductID = 6,
                        Name = "Sapato Social Vegan-Weather",
                        Title = "Sapato Social Vegano",
                        Price = 150.90,
                        Description = "Ecological",
                        Type = "Calcado",
                        Gender = "Masc",
                        isActive = true,
                    },
            });
            #endregion
        }
    }
}
