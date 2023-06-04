using BookCatalogAPI_Domains.Models.Author;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalogAPI_Infraestructure.EntityTypeConfigurations
{
    public class AuthorEntityTypeConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.ToTable("Authors");

            builder.Property(x => x.Id).IsRequired();
            builder.HasKey(x => x.Id);
        }
    }
}
