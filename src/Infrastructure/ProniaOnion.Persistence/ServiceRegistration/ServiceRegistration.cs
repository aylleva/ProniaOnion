using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProniaOnion.Application.Abstractions.Repositories;
using ProniaOnion.Application.Abstractions.Services;
using ProniaOnion.Domain.Entities;
using ProniaOnion.Persistence.Contexts;
using ProniaOnion.Persistence.Implementations.Repositories;
using ProniaOnion.Persistence.Implementations.Services;
using System.Reflection;


namespace ProniaOnion.Persistence.ServiceRegistration
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<AppDBContext>(opt =>
             opt.UseSqlServer(configuration.GetConnectionString("Default"),
             m=>m.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName)
              ));

            services.AddIdentity<AppUser, IdentityRole>(opt =>
            {
                opt.Password.RequiredLength = 8;
                opt.Password.RequireNonAlphanumeric = false;

                opt.User.RequireUniqueEmail = true;

                opt.Lockout.AllowedForNewUsers = true;
                opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1);
                opt.Lockout.MaxFailedAccessAttempts = 3;
            }
            ).AddEntityFrameworkStores<AppDBContext>().AddDefaultTokenProviders();

            services.AddScoped<IProductRepository,ProductRepository>();
            services.AddScoped<IProductService,ProductService>();

            services.AddScoped<ICategoryRepository, CategoryRepository>(); 
            services.AddScoped<IColorRepository,ColorRepository>();

            services.AddScoped<ICategoryService,CategoryService>();
            services.AddScoped<IColorService, ColorService>();

            services.AddScoped<ITagRepository,TagRepository>();
            services.AddScoped<ITagService,TagService>();

            services.AddScoped<ISizeRepository, SizeRepository>();
            services.AddScoped<ISizeService, SizeService>();

            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IAuthorService, AuthorService>();

            services.AddScoped<IGenreRepository, GenreRepository>();
            services.AddScoped<IGenreService, GenreService>();

            services.AddScoped<IBlogRepository, BlogRepository>();
            services.AddScoped<IBlogService, BlogService>();

            services.AddScoped<IAuthenticationService, AuthenticationService>();
            return services;
        }
    }
}
