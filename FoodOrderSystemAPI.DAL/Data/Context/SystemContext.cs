using Microsoft.EntityFrameworkCore;

namespace FoodOrderSystemAPI;

public class SystemContext : DbContext
{
    #region models
    // !!!!!!! UNCOMMENT DBSET ONLY WHEN MODEL IS READY !!!!!!!!!!!!!!

    //internal DbSet<AdminModel> Admins => Set<AdminModel>();
    //internal DbSet<CustomerModel> Customers => Set<CustomerModel>();
    //internal DbSet<OrderModel> Orders => Set<OrderModel>();
    //internal DbSet<OrderProductModel> OrdersProducts => Set<OrderProductModel>();
    //internal DbSet<ProductModel> Products => Set<ProductModel>();
    //internal DbSet<RestaurantModel> Restaurants => Set<RestaurantModel>();
    //internal DbSet<ReviewModel> Reviews => Set<ReviewModel>();
    #endregion
    public DbSet<OrderModel> Orders => Set<OrderModel>();

    public SystemContext(DbContextOptions<SystemContext> options) : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ReviewModel>()
            .HasKey(e => new { e.ProductId, e.CustomerId });
        modelBuilder.Entity<OrderProductModel>()
            .HasKey(e => new {e.OrderId, e.ProductId });
        base.OnModelCreating(modelBuilder);
    }
}
