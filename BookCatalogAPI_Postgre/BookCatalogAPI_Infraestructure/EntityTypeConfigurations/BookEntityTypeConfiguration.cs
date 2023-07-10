using BookCatalogAPI_Domains.Models.Author;
using BookCatalogAPI_Domains.Models.Book;
using BookCatalogAPI_Domains.Models.CategoryBook;
using BookCatalogAPI_Domains.Models.TypeUser;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalogAPI_Infraestructure.EntityTypeConfigurations
{
    public class BookEntityTypeConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Books");

            builder.Property(x => x.Id).IsRequired();
            builder.HasKey(x => x.Id);

            builder.HasOne<Author>()
                .WithMany()
                .HasForeignKey("AuthorId")
                .IsRequired();

            builder.HasOne<CategoryBook>()
                .WithMany()
                .HasForeignKey("CategoryBookId")
                .IsRequired();
        }
    }
}
