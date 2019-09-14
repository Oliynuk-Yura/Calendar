using Calendar.Data.Database;
using Calendar.Data.Domain;
using Calendar.Data.Repository.Abstract.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Calendar.Data.Repository.Implementation.Common
{    
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
          where TEntity : Identifiable
    {
        private readonly CalendarContext _context;

        public GenericRepository(CalendarContext context)
        {
            _context = context;
        }

        public CalendarContext Context
        {
            get { return _context; }
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await Context.Set<TEntity>().ToListAsync();
        }

        public async Task AddAsync(TEntity entity)
        {
            await Context.Set<TEntity>().AddAsync(entity);
            await Context.SaveChangesAsync();
        }

        public async Task<TEntity> DeleteAsync(Guid id)
        {
           var entity =  await Context.Set<TEntity>().FindAsync(id);
           if(entity != null)
           {
               Context.Set<TEntity>().Remove(entity);
               await Context.SaveChangesAsync();
           }

            return entity;
        }

        public Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}


