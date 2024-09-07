using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using ProniaOnionTest.Application.Abstractions.Repositories;
using ProniaOnionTest.Application.Abstractions.Services;
using ProniaOnionTest.Domain.Entities;
using ProniaOnionTest.Persistence.Contexts;
using ProniaOnionTest.Persistence.Implementations.Repositories;
using ProniaOnionTest.Persistence.Implementations.Services;
using System.Reflection;


namespace ProniaOnionTest.Persistence.ServiceRegistration
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("Default"),
                b => b.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName)));

            services.AddIdentity<AppUser, IdentityRole>(opt =>
            {
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequiredLength = 8;

                opt.User.RequireUniqueEmail = true;

                // Default Lockout settings.
                opt.Lockout.MaxFailedAccessAttempts = 5;
                opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                opt.Lockout.AllowedForNewUsers = true;
            }).AddDefaultTokenProviders().AddEntityFrameworkStores<AppDbContext>();

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICategoryService, CategoryService>();

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();

            services.AddScoped<IColorRepository, ColorRepository>();

            services.AddScoped<IAuthenticationService, AuthenticationService>();


            return services;
        }
    }
}
