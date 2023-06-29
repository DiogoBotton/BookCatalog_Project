using BookCatalogAPI;
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
using BookCatalogAPI_Services.Services.AuthorServices.Interface;
using BookCatalogAPI_Services.Services.AuthorServices;
using BookCatalogAPI_Services.Services.BookServices.Interface;
using BookCatalogAPI_Services.Services.BookServices;
using BookCatalogAPI_Services.Services.UserServices.Interface;
using BookCatalogAPI_Services.Services.UserServices;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using BookCatalogAPI.Helpers;

var builder = WebApplication.CreateBuilder(args);
//builder.WebHost.UseUrls("http://*:" + Environment.GetEnvironmentVariable("PORT"));

// Classe startup criada para seguir os mesmos padrões API, mas lembrando que no .NET 6 não seria necessário
//var startup = new Startup(builder.Configuration);
//startup.ConfigureServices(builder.Services);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BookCatalogContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
    sqlServerOptionsAction: sqlOptions =>
    {
        sqlOptions.MigrationsAssembly(typeof(Startup).GetTypeInfo().Assembly.GetName().Name);
        //sqlOptions.EnableRetryOnFailure();
    });
}, ServiceLifetime.Scoped);

// DI (Dependency Injection)
// Repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ITypeUserRepository, TypeUserRepository>();
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBookCommentsRepository, BookCommentsRepository>();
builder.Services.AddScoped<IBooksPurchaseOrderRepository, BooksPurchaseOrderRepository>();
builder.Services.AddScoped<IPurchaseOrderRepository, PurchaseOrderRepository>();
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<ICategoryBookRepository, CategoryBookRepository>();

// builder.Services
builder.Services.AddScoped<IUserServices, UserServices>();
builder.Services.AddScoped<IBookServices, BookServices>();
builder.Services.AddScoped<IAuthorServices, AuthorServices>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
                      builder =>
                      {
                          builder.WithOrigins("http://localhost:5173")
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                      });
});

var app = builder.Build();
//startup.Configure(app, app.Environment, app.Lifetime);

app.Lifetime.ApplicationStarted.Register(() =>
{
    app.ActiveJobs();
});

if (app.Environment.IsDevelopment())
{
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
