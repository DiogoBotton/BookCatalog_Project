using BookCatalogAPI;

var builder = WebApplication.CreateBuilder(args);

// Classe startup criada para seguir os mesmos padr�es API, mas lembrando que no .NET 6 n�o seria necess�rio
var startup = new Startup(builder.Configuration);
startup.ConfigureServices(builder.Services);

var app = builder.Build();
startup.Configure(app, app.Environment, app.Lifetime);

app.Run();
