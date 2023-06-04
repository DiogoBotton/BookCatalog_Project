using BookCatalogAPI_Domains.Models.User;
using BookCatalogAPI_Domains.Models.User.Interfaces;
using BookCatalogAPI_Infraestructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalogAPI_Infraestructure.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(BookCatalogContext ctx) : base(ctx)
        {
        }
    }
}
