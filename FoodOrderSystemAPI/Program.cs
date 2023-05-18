using FoodOrderSystemAPI.DAL;
using Microsoft.EntityFrameworkCore;

namespace FoodOrderSystemAPI;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        #region Default Services
        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        #endregion

        #region Context
        var connectionString = builder.Configuration.GetConnectionString("FoodOrderSystemDB_ConStr");
        builder.Services.AddDbContext<SystemContext>(options => options.UseSqlServer(connectionString));
        #endregion

        #region Repos and UOW
        builder.Services.AddTransient<IAdminRepo, AdminRepo>();
        builder.Services.AddTransient<ICustomerRepo, CustomerRepo>();
        builder.Services.AddTransient<IOrderProductRepo, OrderProductRepo>();
        builder.Services.AddTransient<IOrderRepo, OrderRepo>();
        builder.Services.AddTransient<IProductRepo, ProductRepo>();
        builder.Services.AddTransient<IRestaurantRepo, RestaurantRepo>();
        builder.Services.AddTransient<IReviewRepo, ReviewRepo>();
        // unit of work
        builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
        #endregion

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}