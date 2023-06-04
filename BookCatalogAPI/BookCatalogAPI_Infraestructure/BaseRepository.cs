using BookCatalogAPI_Domains;
using BookCatalogAPI_Infraestructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookCatalogAPI_Infraestructure
{
    public abstract class BaseRepository<T> : IRepository<T> where T : AbstractDomain
    {
        protected BookCatalogContext _ctx;
        private DbSet<T> _entity;
        IUnitOfWork IRepository<T>.UnitOfWork => _ctx;

        protected BaseRepository(BookCatalogContext ctx)
        {
            _ctx = ctx;
            _entity = _ctx.Set<T>();
        }

        public async Task<T> CreateAsync(T objeto)
        {
            return await Task.FromResult(_entity.AddAsync(objeto).Result.Entity);
        }

        public async Task<bool> UpdateAsync(T objeto)
        {
            try
            {
                await Task.FromResult(_entity.Update(objeto));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public T? GetById(long id) =>
            _entity.FirstOrDefault(x => x.Id == id);

        public async Task<List<T>> GetAllAsync() =>
            await _entity.ToListAsync();
    }
}
