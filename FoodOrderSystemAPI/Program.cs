using FluentValidation;
using FluentValidation.AspNetCore;
using FoodOrderSystemAPI.DAL;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

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

        #region Context Service
        var connectionString = builder.Configuration.GetConnectionString("FoodOrderSystemDB_ConStr");
        builder.Services.AddDbContext<SystemContext>(options => options.UseSqlServer(connectionString));
        #endregion

        #region Repos and UOW Services
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

        #region Third party packages Services
        builder.Services.AddAutoMapper(typeof(Program).Assembly);
        // FluentValidation
        builder.Services.AddFluentValidationAutoValidation();
        builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        #endregion

        //#region Validator Services

        //#endregion

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