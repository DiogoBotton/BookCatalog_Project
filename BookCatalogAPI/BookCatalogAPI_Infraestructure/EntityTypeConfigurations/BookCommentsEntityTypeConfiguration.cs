using BookCatalogAPI_Domains.Models.Book;
using BookCatalogAPI_Domains.Models.BookComments;
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
    public class BookCommentsEntityTypeConfiguration : IEntityTypeConfiguration<BookComments>
    {
        public void Configure(EntityTypeBuilder<BookComments> builder)
        {
            builder.ToTable("BooksComments");

            builder.Property(x => x.Id).IsRequired();
            builder.HasKey(x => x.Id);

            builder.HasOne<Book>()
                .WithMany()
                .HasForeignKey("BookId")
                .IsRequired();
        }
    }
}
