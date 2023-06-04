using BookCatalogAPI_Domains.Models.Author;
using BookCatalogAPI_Domains.Models.CategoryBook;
using BookCatalogAPI_Domains.Models.TypeUser;
using BookCatalogAPI_Infraestructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace BookCatalogAPI.Helpers
{
    public static class Jobs
    {
        public static async void ActiveJobs(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var ctx = serviceScope.ServiceProvider.GetService<BookCatalogContext>();
                if (ctx != null)
                    await AddDefaultValuesAsyncDb(ctx);
            }
        }

        private static async Task AddDefaultValuesAsyncDb(BookCatalogContext ctx)
        {
            // Para funcionar:
            // Antes necessário digitar o comando "add-migration"
            // No arquivo appsettings.json, na seção de DefaultConnection do BD, acrescentar o paramêtro "TrustServerCertificate=True"
            //ctx.Database.Migrate();

            if(!ctx.TypeUsers.Any())
            {
                await ctx.TypeUsers.AddRangeAsync(new List<TypeUser>()
                {
                    new TypeUser("Comum"),
                    new TypeUser("Administrador"),
                });
            }
            
            if(!ctx.Authors.Any())
            {
                await ctx.Authors.AddRangeAsync(new List<Author>()
                {
                    new Author("George Orwell"),
                    new Author("J.R.R Tolkien"),
                });
            }
            
            if(!ctx.CategoryBooks.Any())
            {
                await ctx.CategoryBooks.AddRangeAsync(new List<CategoryBook>()
                {
                    new CategoryBook("Terror"),
                    new CategoryBook("Ficção Científica"),
                    new CategoryBook("Fantasia"),
                    new CategoryBook("Aventura"),
                    new CategoryBook("HQ"),
                    new CategoryBook("Thriller"),
                    new CategoryBook("Coach")
                });
            }

            await ctx.SaveDbChanges();
        }
    }
}
