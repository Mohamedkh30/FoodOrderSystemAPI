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



        modelBuilder.Entity<CustomerModel>().ToTable("CustomerModel");
        modelBuilder.Entity<RestaurantModel>().ToTable("RestaurantModel");





        base.OnModelCreating(modelBuilder);


    }

}
