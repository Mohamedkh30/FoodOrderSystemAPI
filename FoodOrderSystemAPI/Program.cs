using FoodOrderSystemAPI.BL;
using FluentValidation;
using FluentValidation.AspNetCore;
using FoodOrderSystemAPI.DAL;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
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

        builder.Services.AddCors(options =>
         {
             options.AddDefaultPolicy(
                 builder =>
                 {
                     builder.AllowAnyOrigin()
                         .AllowAnyMethod()
                         .AllowAnyHeader();
                 });
         });

        #region Context
        var connectionString = builder.Configuration.GetConnectionString("FoodOrderSystemDB_ConStr");
        builder.Services.AddDbContext<SystemContext>(options => options.UseSqlServer(connectionString));
        #endregion

        #region Identity User
        builder.Services.AddIdentity<CustomerModel, IdentityRole<int>>(options =>
        {
            options.Lockout.MaxFailedAccessAttempts = 5;
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(2);

        }).AddEntityFrameworkStores<SystemContext>();
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

        #region Third party packages Services
        builder.Services.AddAutoMapper(typeof(Program).Assembly);
        // FluentValidation
        builder.Services.AddFluentValidationAutoValidation();
        builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        #endregion


        #region  Authentcation Scheama 
        //Change the Default behavior of Authentcation Schema From Coockie Authentcation
        builder.Services.AddAuthentication(options =>
        {
            options.DefaultChallengeScheme = "default";
            options.DefaultAuthenticateScheme = "default";
        })
    .AddJwtBearer("default", options =>
            {
                var secretkey = builder.Configuration.GetValue<string>("secretkey");
                var secretkeyinbytes = Encoding.ASCII.GetBytes(secretkey);
                var key = new SymmetricSecurityKey(secretkeyinbytes);
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = key
                };
            });
        #endregion

        #region autherization

        builder.Services.AddAuthorization(options =>
        {
            options.AddPolicy("Customer", policy => policy
                .RequireClaim(ClaimTypes.Role, "Customer", "Admin")
                .RequireClaim(ClaimTypes.NameIdentifier));

        });
        #endregion


        #region Managers
        builder.Services.AddTransient<ICustomerManager, CustomerManager>();

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

        app.UseCors();
        app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}