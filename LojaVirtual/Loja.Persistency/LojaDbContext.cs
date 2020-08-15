using Loja.Application;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Loja.Persistency
{
    public class LojaDbContext : IdentityDbContext, IApplicationDbContext
    {
        public LojaDbContext(DbContextOptions<LojaDbContext> options) : base(options) { }
        public DbSet<Client> Client { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Order> Order { get; set; }
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
            #endregion

            //Model<Order>
            #region
            builder.Entity<Order>()
                .HasMany(c => c.Products)
                .WithOne(c => c.Order)
                .HasForeignKey(c => c.OrderID);

            builder.Entity<Order>()
                .HasOne(c => c.AddressShip)
                .WithMany(c => c.Orders)
                .HasForeignKey(c => c.OrderID);
            #endregion
        }
    }
}
