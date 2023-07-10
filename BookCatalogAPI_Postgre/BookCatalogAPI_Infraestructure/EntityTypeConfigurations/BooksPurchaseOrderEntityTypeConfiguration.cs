using BookCatalogAPI_Domains.Models.Book;
using BookCatalogAPI_Domains.Models.BooksPurchaseOrder;
using BookCatalogAPI_Domains.Models.PurchaseOrder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalogAPI_Infraestructure.EntityTypeConfigurations
{
    public class BooksPurchaseOrderEntityTypeConfiguration : IEntityTypeConfiguration<BooksPurchaseOrder>
    {
        public void Configure(EntityTypeBuilder<BooksPurchaseOrder> builder)
        {
            builder.ToTable("BooksPurchaseOrder");

            builder.Property(x => x.Id).IsRequired();
            builder.HasKey(x => x.Id);

            builder.HasOne<Book>()
                .WithMany()
                .HasForeignKey("BookId")
                .IsRequired();

            builder.HasOne<PurchaseOrder>()
                .WithMany()
                .HasForeignKey("PurchaseOrderId")
                .IsRequired();
        }
    }
}
