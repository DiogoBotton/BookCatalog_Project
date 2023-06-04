using BookCatalogAPI;

var builder = WebApplication.CreateBuilder(args);

// Classe startup criada para seguir os mesmos padrões API, mas lembrando que no .NET 6 não seria necessário
var startup = new Startup(builder.Configuration);
startup.ConfigureServices(builder.Services);

var app = builder.Build();
startup.Configure(app, app.Environment, app.Lifetime);

app.Run();
