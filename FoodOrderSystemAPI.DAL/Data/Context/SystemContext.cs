using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FoodOrderSystemAPI;

public class SystemContext : IdentityDbContext<UserModel>
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
    #endregion

    public SystemContext(DbContextOptions<SystemContext> options) : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OrderProductModel>()
            .HasKey(e => new {e.OrderId, e.ProductId });
        
        modelBuilder.Entity<ReviewModel>()
            .HasKey(e => new {e.CustomerID, e.ProductID });

        modelBuilder.Entity<Location>().HasNoKey();
        modelBuilder.Entity<CreditCard>().HasNoKey();

        modelBuilder.Entity<CustomerModel>().ToTable("CustomerModel");
        modelBuilder.Entity<RestaurantModel>().ToTable("RestaurantModel");
        base.OnModelCreating(modelBuilder);
    }

}
