using BookCatalogAPI_Domains;
using BookCatalogAPI_Domains.Models.Author;
using BookCatalogAPI_Domains.Models.Book;
using BookCatalogAPI_Domains.Models.BookComments;
using BookCatalogAPI_Domains.Models.BooksPurchaseOrder;
using BookCatalogAPI_Domains.Models.CategoryBook;
using BookCatalogAPI_Domains.Models.PurchaseOrder;
using BookCatalogAPI_Domains.Models.TypeUser;
using BookCatalogAPI_Domains.Models.User;
using BookCatalogAPI_Infraestructure.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalogAPI_Infraestructure.Contexts
{
    public class BookCatalogContext : DbContext, IUnitOfWork
    {
        public DbSet<User> Users { get; set; }
        public DbSet<TypeUser> TypeUsers { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<CategoryBook> CategoryBooks { get; set; }
        public DbSet<BookComments> BookComments { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public DbSet<BooksPurchaseOrder> BooksPurchaseOrders { get; set; }
        public BookCatalogContext(DbContextOptions<BookCatalogContext> options) : base(options)
        {
        }

        public BookCatalogContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new TypeUserEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new BookEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryBookEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new BookCommentsEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new AuthorEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PurchaseOrderEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new BooksPurchaseOrderEntityTypeConfiguration());
        }

        public async Task SaveDbChanges(CancellationToken cancellationToken = default)
        {
            await base.SaveChangesAsync();
        }
    }
}
