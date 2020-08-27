﻿// <auto-generated />
using System;
using Loja.Persistency;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Loja.Persistency.Migrations
{
    [DbContext(typeof(LojaDbContext))]
    partial class LojaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7");

            modelBuilder.Entity("Loja.Address", b =>
                {
                    b.Property<int>("AddressID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AddressName")
                        .HasColumnType("TEXT");

                    b.Property<string>("AddressType")
                        .HasColumnType("TEXT");

                    b.Property<string>("City")
                        .HasColumnType("TEXT");

                    b.Property<int>("ClientID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Complemention")
                        .HasColumnType("TEXT");

                    b.Property<string>("Country")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("TEXT");

                    b.Property<string>("District")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("TEXT");

                    b.Property<string>("Number")
                        .HasColumnType("TEXT");

                    b.Property<string>("State")
                        .HasColumnType("TEXT");

                    b.Property<bool>("isActive")
                        .HasColumnType("INTEGER");

                    b.HasKey("AddressID");

                    b.HasIndex("ClientID");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("Loja.Client", b =>
                {
                    b.Property<int>("ClientID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("CPF")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserID")
                        .HasColumnType("TEXT");

                    b.Property<bool>("isActive")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("isAdmin")
                        .HasColumnType("INTEGER");

                    b.HasKey("ClientID");

                    b.ToTable("Client");

                    b.HasData(
                        new
                        {
                            ClientID = 1,
                            BirthDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "admin@loja.com",
                            LastModified = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Admin",
                            Password = "TESTE",
                            isActive = true,
                            isAdmin = true
                        });
                });

            modelBuilder.Entity("Loja.Domain.Database", b =>
                {
                    b.Property<int>("DatabaseID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("TEXT");

                    b.Property<string>("Link")
                        .HasColumnType("TEXT");

                    b.Property<int>("ProductID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Type")
                        .HasColumnType("TEXT");

                    b.HasKey("DatabaseID");

                    b.HasIndex("ProductID");

                    b.ToTable("Databases");
                });

            modelBuilder.Entity("Loja.Domain.Item", b =>
                {
                    b.Property<int>("ItemID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("OrderID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.HasKey("ItemID");

                    b.HasIndex("OrderID");

                    b.ToTable("Item");
                });

            modelBuilder.Entity("Loja.Domain.StockSize", b =>
                {
                    b.Property<int>("StockSizeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("TEXT");

                    b.Property<int>("ProductID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Size")
                        .HasColumnType("TEXT");

                    b.Property<int>("Stock")
                        .HasColumnType("INTEGER");

                    b.HasKey("StockSizeID");

                    b.HasIndex("ProductID");

                    b.ToTable("StockSize");

                    b.HasData(
                        new
                        {
                            StockSizeID = 1,
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastModified = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ProductID = 1,
                            Size = "42",
                            Stock = 9
                        },
                        new
                        {
                            StockSizeID = 2,
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastModified = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ProductID = 1,
                            Size = "46",
                            Stock = 3
                        },
                        new
                        {
                            StockSizeID = 3,
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastModified = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ProductID = 2,
                            Size = "G",
                            Stock = 12
                        },
                        new
                        {
                            StockSizeID = 4,
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastModified = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ProductID = 2,
                            Size = "P",
                            Stock = 5
                        },
                        new
                        {
                            StockSizeID = 5,
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastModified = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ProductID = 3,
                            Size = "M",
                            Stock = 5
                        },
                        new
                        {
                            StockSizeID = 6,
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastModified = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ProductID = 3,
                            Size = "XXG",
                            Stock = 7
                        },
                        new
                        {
                            StockSizeID = 7,
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastModified = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ProductID = 4,
                            Size = "38",
                            Stock = 3
                        },
                        new
                        {
                            StockSizeID = 8,
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastModified = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ProductID = 4,
                            Size = "43",
                            Stock = 7
                        },
                        new
                        {
                            StockSizeID = 9,
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastModified = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ProductID = 5,
                            Size = "41",
                            Stock = 3
                        },
                        new
                        {
                            StockSizeID = 10,
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastModified = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ProductID = 5,
                            Size = "37",
                            Stock = 8
                        },
                        new
                        {
                            StockSizeID = 11,
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastModified = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ProductID = 6,
                            Size = "44",
                            Stock = 2
                        },
                        new
                        {
                            StockSizeID = 12,
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastModified = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ProductID = 6,
                            Size = "38",
                            Stock = 3
                        });
                });

            modelBuilder.Entity("Loja.Order", b =>
                {
                    b.Property<int>("OrderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AddressID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClientID")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("TEXT");

                    b.Property<string>("Status")
                        .HasColumnType("TEXT");

                    b.Property<string>("TypePayment")
                        .HasColumnType("TEXT");

                    b.HasKey("OrderID");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("Loja.Product", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClientID")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Gender")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .HasColumnType("TEXT");

                    b.Property<bool>("isActive")
                        .HasColumnType("INTEGER");

                    b.HasKey("ProductID");

                    b.HasIndex("ClientID");

                    b.ToTable("Product");

                    b.HasData(
                        new
                        {
                            ProductID = 1,
                            ClientID = 1,
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Ótima lavagem, longa duração",
                            Gender = "Fem",
                            LastModified = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Calça Jeans Strech",
                            Price = 50.899999999999999,
                            Title = "Calça Jeans Super Pure Strech",
                            Type = "Calça",
                            isActive = true
                        },
                        new
                        {
                            ProductID = 2,
                            ClientID = 1,
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Impermeável",
                            Gender = "Masc",
                            LastModified = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Blusa Ultra Dry",
                            Price = 70.5,
                            Title = "Blusa de Manga Longa",
                            Type = "Blusa",
                            isActive = true
                        },
                        new
                        {
                            ProductID = 3,
                            ClientID = 1,
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Alta Costura",
                            Gender = "Both",
                            LastModified = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Jaqueta Minimalista Limited Edition",
                            Price = 110.09999999999999,
                            Title = "Jaqueta Minimalista",
                            Type = "Calça",
                            isActive = true
                        },
                        new
                        {
                            ProductID = 4,
                            ClientID = 1,
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Ultra weight",
                            Gender = "Both",
                            LastModified = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Tennis Vintage 90'",
                            Price = 190.5,
                            Title = "Tennis Vintage",
                            Type = "Calcado",
                            isActive = true
                        },
                        new
                        {
                            ProductID = 5,
                            ClientID = 1,
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Confort Plus",
                            Gender = "Fem",
                            LastModified = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Sapatilha Confort Plus",
                            Price = 170.90000000000001,
                            Title = "Sapatilha Confortável",
                            Type = "Calcado",
                            isActive = true
                        },
                        new
                        {
                            ProductID = 6,
                            ClientID = 1,
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Ecological",
                            Gender = "Masc",
                            LastModified = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Sapato Social Vegan-Weather",
                            Price = 150.90000000000001,
                            Title = "Sapato Social Vegano",
                            Type = "Calcado",
                            isActive = true
                        });
                });

            modelBuilder.Entity("Loja.Address", b =>
                {
                    b.HasOne("Loja.Client", "Client")
                        .WithMany("Addresses")
                        .HasForeignKey("ClientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Loja.Domain.Database", b =>
                {
                    b.HasOne("Loja.Product", "Product")
                        .WithMany("Database")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Loja.Domain.Item", b =>
                {
                    b.HasOne("Loja.Order", "Order")
                        .WithMany("Items")
                        .HasForeignKey("OrderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Loja.Product", "Product")
                        .WithMany("Items")
                        .HasForeignKey("OrderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Loja.Domain.StockSize", b =>
                {
                    b.HasOne("Loja.Product", "Product")
                        .WithMany("StockSize")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Loja.Order", b =>
                {
                    b.HasOne("Loja.Address", "AddressShip")
                        .WithMany("Orders")
                        .HasForeignKey("OrderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Loja.Client", "Client")
                        .WithMany("Orders")
                        .HasForeignKey("OrderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Loja.Product", b =>
                {
                    b.HasOne("Loja.Client", "Client")
                        .WithMany("Products")
                        .HasForeignKey("ClientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
