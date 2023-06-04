using BookCatalogAPI_Domains.Models.User.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookCatalogAPI_Domains.Models.TypeUser.Interfaces;
using BookCatalogAPI_Domains.Models.TypeUser;
using BookCatalogAPI_Infraestructure.Contexts;

namespace BookCatalogAPI_Infraestructure.Repositories
{
    public class TypeUserRepository : BaseRepository<TypeUser>, ITypeUserRepository
    {
        public TypeUserRepository(BookCatalogContext ctx) : base(ctx)
        {
        }
    }
}
