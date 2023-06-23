﻿// <auto-generated />
using System;
using FoodOrderSystemAPI;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FoodOrderSystemAPI.DAL.Migrations
{
    [DbContext(typeof(SystemContext))]
    partial class SystemContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FoodOrderSystemAPI.CreditCard", b =>
                {
                    b.Property<int>("CreditId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CreditId"));

                    b.Property<string>("CVV")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Card_Expiration_Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Card_Number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.HasKey("CreditId");

                    b.HasIndex("CustomerId")
                        .IsUnique();

                    b.ToTable("CreditCards");
                });

            modelBuilder.Entity("FoodOrderSystemAPI.DAL.ProductTag", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("tag")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ProductId", "tag");

                    b.ToTable("ProductTags");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            tag = "vegetarian"
                        },
                        new
                        {
                            ProductId = 1,
                            tag = "local"
                        },
                        new
                        {
                            ProductId = 2,
                            tag = "vegetarian"
                        },
                        new
                        {
                            ProductId = 2,
                            tag = "local"
                        },
                        new
                        {
                            ProductId = 3,
                            tag = "vegetarian"
                        },
                        new
                        {
                            ProductId = 3,
                            tag = "local"
                        },
                        new
                        {
                            ProductId = 4,
                            tag = "local"
                        });
                });

            modelBuilder.Entity("FoodOrderSystemAPI.Location", b =>
                {
                    b.Property<int>("LocationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LocationId"));

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

                    b.HasKey("LocationId");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("FoodOrderSystemAPI.OrderModel", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("OrderStatus")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("TotalPrice")
                        .HasColumnType("int");

                    b.HasKey("OrderId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("FoodOrderSystemAPI.OrderProductModel", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.Property<int>("ProductId")
                        .HasColumnType("int")
                        .HasColumnOrder(2);

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("OrderId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrdersProducts");
                });

            modelBuilder.Entity("FoodOrderSystemAPI.ProductModel", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<string>("Productname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RestaurantID")
                        .HasColumnType("int");

                    b.Property<string>("describtion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("img")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("offer")
                        .HasColumnType("real");

                    b.Property<float>("price")
                        .HasColumnType("real");

                    b.Property<float>("rate")
                        .HasColumnType("real");

                    b.HasKey("ProductId");

                    b.HasIndex("RestaurantID");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            Productname = "Flafel",
                            RestaurantID = 1,
                            describtion = "flafel so5na",
                            img = "https://www.holidaysmart.com/sites/default/files/daily/2020/falafel-shs_1500.jpg",
                            offer = 0.45555f,
                            price = 3f,
                            rate = 4f
                        },
                        new
                        {
                            ProductId = 2,
                            Productname = "fool",
                            RestaurantID = 1,
                            describtion = "fool so5n",
                            img = "https://kitchen.sayidaty.net/uploads/small/42/423203a50a85745ee5ff98ff201043f7_w750_h500.jpg",
                            offer = 0f,
                            price = 5f,
                            rate = 2f
                        },
                        new
                        {
                            ProductId = 3,
                            Productname = "Koshary",
                            RestaurantID = 1,
                            describtion = "Koshary so5n",
                            img = "https://i.pinimg.com/originals/4c/37/99/4c37995da59d3e4cdf0da7c57084e2f5.jpg",
                            offer = 0.5f,
                            price = 20f,
                            rate = 4f
                        },
                        new
                        {
                            ProductId = 4,
                            Productname = "kebda",
                            RestaurantID = 1,
                            describtion = "kebda so5na",
                            img = "https://egy-news.net/im0photos/20220919/T16635700676390e53d7bc4b1cbbd92af455195f691image.jpg&w=1200&h=675&img.jpg",
                            offer = 0.1f,
                            price = 30f,
                            rate = 3f
                        });
                });

            modelBuilder.Entity("FoodOrderSystemAPI.ReviewModel", b =>
                {
                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.HasKey("CustomerId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("ReviewModel");
                });

            modelBuilder.Entity("FoodOrderSystemAPI.UserModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("FoodOrderSystemAPI.AdminModel", b =>
                {
                    b.HasBaseType("FoodOrderSystemAPI.UserModel");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("FoodOrderSystemAPI.CustomerModel", b =>
                {
                    b.HasBaseType("FoodOrderSystemAPI.UserModel");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CustomerAddressLocationId")
                        .HasColumnType("int");

                    b.HasIndex("CustomerAddressLocationId");

                    b.ToTable("CustomerModel", (string)null);
                });

            modelBuilder.Entity("FoodOrderSystemAPI.RestaurantModel", b =>
                {
                    b.HasBaseType("FoodOrderSystemAPI.UserModel");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Logo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PaymentMethods")
                        .HasColumnType("int");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RestaurantName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.ToTable("RestaurantModel", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "e2c0f8eb-c55b-421b-8c84-d7e60a20b514",
                            Email = "test",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "",
                            NormalizedUserName = "Mohamed Ahmed",
                            PhoneNumberConfirmed = false,
                            Role = 0,
                            TwoFactorEnabled = false,
                            UserName = "Mohamed Ahmed",
                            Address = "test",
                            Logo = "",
                            PaymentMethods = 1,
                            Phone = "",
                            RestaurantName = "Mohamed Ahmed"
                        },
                        new
                        {
                            Id = 2,
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "a20e63ea-7d6a-4381-a248-b31f4541e45e",
                            Email = "test",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "",
                            NormalizedUserName = "KFC",
                            PhoneNumberConfirmed = false,
                            Role = 0,
                            TwoFactorEnabled = false,
                            UserName = "KFC",
                            Address = "test",
                            Logo = "",
                            PaymentMethods = 1,
                            Phone = "",
                            RestaurantName = "KFC"
                        });
                });

            modelBuilder.Entity("FoodOrderSystemAPI.CreditCard", b =>
                {
                    b.HasOne("FoodOrderSystemAPI.CustomerModel", "Customer")
                        .WithOne("CustomerCreditCard")
                        .HasForeignKey("FoodOrderSystemAPI.CreditCard", "CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("FoodOrderSystemAPI.DAL.ProductTag", b =>
                {
                    b.HasOne("FoodOrderSystemAPI.ProductModel", "product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("product");
                });

            modelBuilder.Entity("FoodOrderSystemAPI.OrderModel", b =>
                {
                    b.HasOne("FoodOrderSystemAPI.CustomerModel", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("FoodOrderSystemAPI.OrderProductModel", b =>
                {
                    b.HasOne("FoodOrderSystemAPI.OrderModel", "Order")
                        .WithMany("OrderProducts")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FoodOrderSystemAPI.ProductModel", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("FoodOrderSystemAPI.ProductModel", b =>
                {
                    b.HasOne("FoodOrderSystemAPI.RestaurantModel", "restaurant")
                        .WithMany("Products")
                        .HasForeignKey("RestaurantID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("restaurant");
                });

            modelBuilder.Entity("FoodOrderSystemAPI.ReviewModel", b =>
                {
                    b.HasOne("FoodOrderSystemAPI.CustomerModel", "Customer")
                        .WithMany("Reviews")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FoodOrderSystemAPI.ProductModel", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("FoodOrderSystemAPI.UserModel", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("FoodOrderSystemAPI.UserModel", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FoodOrderSystemAPI.UserModel", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("FoodOrderSystemAPI.UserModel", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FoodOrderSystemAPI.CustomerModel", b =>
                {
                    b.HasOne("FoodOrderSystemAPI.Location", "CustomerAddress")
                        .WithMany()
                        .HasForeignKey("CustomerAddressLocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FoodOrderSystemAPI.UserModel", null)
                        .WithOne()
                        .HasForeignKey("FoodOrderSystemAPI.CustomerModel", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CustomerAddress");
                });

            modelBuilder.Entity("FoodOrderSystemAPI.RestaurantModel", b =>
                {
                    b.HasOne("FoodOrderSystemAPI.UserModel", null)
                        .WithOne()
                        .HasForeignKey("FoodOrderSystemAPI.RestaurantModel", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FoodOrderSystemAPI.OrderModel", b =>
                {
                    b.Navigation("OrderProducts");
                });

            modelBuilder.Entity("FoodOrderSystemAPI.CustomerModel", b =>
                {
                    b.Navigation("CustomerCreditCard")
                        .IsRequired();

                    b.Navigation("Orders");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("FoodOrderSystemAPI.RestaurantModel", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
