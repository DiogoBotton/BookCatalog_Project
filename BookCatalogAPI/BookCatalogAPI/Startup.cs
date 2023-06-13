using BookCatalogAPI.Helpers;
using BookCatalogAPI_Domains.Models.Author.Interfaces;
using BookCatalogAPI_Domains.Models.Book.Interfaces;
using BookCatalogAPI_Domains.Models.BookComments.Interfaces;
using BookCatalogAPI_Domains.Models.BooksPurchaseOrder.Interfaces;
using BookCatalogAPI_Domains.Models.CategoryBook.Interfaces;
using BookCatalogAPI_Domains.Models.PurchaseOrder.Interfaces;
using BookCatalogAPI_Domains.Models.TypeUser.Interfaces;
using BookCatalogAPI_Domains.Models.User.Interfaces;
using BookCatalogAPI_Infraestructure.Contexts;
using BookCatalogAPI_Infraestructure.Repositories;
using BookCatalogAPI_Services.Services.AuthorServices;
using BookCatalogAPI_Services.Services.AuthorServices.Interface;
using BookCatalogAPI_Services.Services.BookServices;
using BookCatalogAPI_Services.Services.BookServices.Interface;
using BookCatalogAPI_Services.Services.UserServices;
using BookCatalogAPI_Services.Services.UserServices.Interface;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BookCatalogAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddDbContext<BookCatalogContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                sqlServerOptionsAction: sqlOptions =>
                {
                    sqlOptions.MigrationsAssembly(typeof(Startup).GetTypeInfo().Assembly.GetName().Name);
                });
            }, ServiceLifetime.Scoped);

            // DI (Dependency Injection)
            // Repositories
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITypeUserRepository, TypeUserRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IBookCommentsRepository, BookCommentsRepository>();
            services.AddScoped<IBooksPurchaseOrderRepository, BooksPurchaseOrderRepository>();
            services.AddScoped<IPurchaseOrderRepository, PurchaseOrderRepository>();
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<ICategoryBookRepository, CategoryBookRepository>();

            // Services
            services.AddScoped<IUserServices, UserServices>();
            services.AddScoped<IBookServices, BookServices>();
            services.AddScoped<IAuthorServices, AuthorServices>();

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                                  builder =>
                                  {
                                      builder.WithOrigins("http://localhost:5173")
                                      .AllowAnyHeader()
                                      .AllowAnyMethod();
                                  });
            });
        }

        public void Configure(WebApplication app, IWebHostEnvironment env, IHostApplicationLifetime lifetime)
        {
            lifetime.ApplicationStarted.Register(() =>
            {
                app.ActiveJobs();
            });

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("CorsPolicy");

            app.UseAuthorization();

            app.MapControllers();
        }
    }
}
