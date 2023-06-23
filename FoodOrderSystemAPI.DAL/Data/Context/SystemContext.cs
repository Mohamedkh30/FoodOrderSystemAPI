using FoodOrderSystemAPI.DAL;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace FoodOrderSystemAPI;

public class SystemContext : IdentityDbContext<UserModel, IdentityRole <int>, int>
{
    #region models
    // !!!!!!! UNCOMMENT DBSET ONLY WHEN MODEL IS READY !!!!!!!!!!!!!!

    internal DbSet<AdminModel> Admins => Set<AdminModel>();
    internal DbSet<CustomerModel> Customers => Set<CustomerModel>();
    internal DbSet<OrderModel> Orders => Set<OrderModel>();
    internal DbSet<OrderProductModel> OrdersProducts => Set<OrderProductModel>();
    internal DbSet<ProductModel> Products => Set<ProductModel>();
    internal DbSet<ProductTag> ProductTags => Set<ProductTag>();
    internal DbSet<RestaurantModel> Restaurants => Set<RestaurantModel>();
    internal DbSet<ReviewModel> Reviews => Set<ReviewModel>();
    internal DbSet<CreditCard> CreditCards => Set<CreditCard>();
    internal DbSet<ReviewModel> Loacntions => Set<ReviewModel>();
    #endregion

    public SystemContext(DbContextOptions<SystemContext> options) : base(options)
    { }
   

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OrderProductModel>()
            .HasKey(e => new {e.OrderId, e.ProductId });
        
        modelBuilder.Entity<ReviewModel>()
            .HasKey(e => new {e.CustomerId, e.ProductId });

        modelBuilder.Entity<ProductTag>()
            .HasKey(e => new { e.ProductId, e.tag });



        modelBuilder.Entity<CustomerModel>().ToTable("CustomerModel");
        modelBuilder.Entity<RestaurantModel>().ToTable("RestaurantModel");


        #region product seed
        modelBuilder.Entity<ProductModel>().HasData(
            new ProductModel { ProductId = 1, Productname = "Flafel", price = 3, describtion = "flafel so5na", img = "https://www.holidaysmart.com/sites/default/files/daily/2020/falafel-shs_1500.jpg", offer = 0.45555f, rate = 4 ,RestaurantID = 1 },
            new ProductModel { ProductId = 2, Productname = "fool", price = 5, describtion = "fool so5n", img = "https://kitchen.sayidaty.net/uploads/small/42/423203a50a85745ee5ff98ff201043f7_w750_h500.jpg", offer = 0, rate = 2, RestaurantID = 1 },
            new ProductModel { ProductId = 3, Productname = "Koshary", price = 20, describtion = "Koshary so5n", img = "https://i.pinimg.com/originals/4c/37/99/4c37995da59d3e4cdf0da7c57084e2f5.jpg", offer = 0.5f, rate = 4, RestaurantID = 1 },
            new ProductModel { ProductId = 4, Productname = "kebda", price = 30, describtion = "kebda so5na", img = "https://egy-news.net/im0photos/20220919/T16635700676390e53d7bc4b1cbbd92af455195f691image.jpg&w=1200&h=675&img.jpg", offer = 0.1f, rate = 3 , RestaurantID = 1 }
        );
        #endregion

        #region product Tags seed
        modelBuilder.Entity<ProductTag>().HasData(
            new ProductTag { ProductId = 1, tag = "vegetarian" },
            new ProductTag { ProductId = 1, tag = "local" },
            new ProductTag { ProductId = 2, tag = "vegetarian" },
            new ProductTag { ProductId = 2, tag = "local" },
            new ProductTag { ProductId = 3, tag = "vegetarian" },
            new ProductTag { ProductId = 3, tag = "local" },
            new ProductTag { ProductId = 4, tag = "local" }
            );
        #endregion

        #region Restaurant seed
        modelBuilder.Entity<RestaurantModel>().HasData(
            new RestaurantModel { Id = 1, RestaurantName = "Mohamed Ahmed",UserName= "Mohamed Ahmed" , Address="test", Email="test" ,PaymentMethods= PaymentType.Cash }//,
            //new RestaurantModel { Id = 2, RestaurantName = "Kebdaky" }
            );
        #endregion


        #region Customer Seed
        //modelBuilder.Entity<CustomerModel>().HasData(
        //    new CustomerModel() { Id = 1, UserName = "hassan mohamed", Email = "hassan@gmail.com", BirthDate = new DateTime(1999, 3, 24), CustomerAddress = new Location() { LocationId = 1, Latitude = .33, Longitude = .22 } , CustomerCreditCard = new CreditCard() { Card_Expiration_Date = new DateTime(2024, 3, 12), Card_Number = "1234123412341234", CVV = "333" }, Role = RoleOptions.Customer },
        //    new CustomerModel() { Id = 2 ,  UserName = "hamdy mohamed", Email = "hamdy@gmail.com", BirthDate = new DateTime(2002, 3, 24), CustomerAddress = new Location() { LocationId = 2 ,  Latitude = .53, Longitude = .62 }, CustomerCreditCard = new CreditCard() { Card_Expiration_Date = new DateTime(2026, 7, 22), Card_Number = "1212121212121212", CVV = "229" }, Role = RoleOptions.Customer }
        //    );
        #endregion 

        base.OnModelCreating(modelBuilder);


    }

}
