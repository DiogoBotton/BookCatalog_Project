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
    public class TypeUserEntityTypeConfiguration : IEntityTypeConfiguration<TypeUser>
    {
        public void Configure(EntityTypeBuilder<TypeUser> builder)
        {
            builder.ToTable("TypeUsers");

            builder.Property(x => x.Id).IsRequired();
            builder.HasKey(x => x.Id);
        }
    }
}
