using ConfRe.Intrastructure.Data;
using ConfReg.Domain.Abstractions;
using ConfReg.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfRe.Intrastructure.Repositories
{
    public class Repository<T>(AppDbContext appDbContext) : IRepository<T> where T : BaseEntity
    {
        private DbSet<T> entities = appDbContext.Set<T>();
        public async Task CreateAsync(T entity)
        {
            if (entities == null) throw new NotImplementedException(nameof(entity));
            await entities.AddAsync(entity);



        }

        public async Task<IList<T>> GetAllAsync()
        {
            return await entities.ToListAsync();
        }

        public async Task<T> GetByIdAsync(object id)
        {
  
            return await entities.FindAsync(id);
        }

        public  Task<bool> IsExist(long id)
        {
            return entities.AnyAsync(c => c.Id == id);
        }

        public void Remove(T entity)
        {
           if (entity == null) throw new ArgumentNullException(nameof(entity));
           entities.Remove(entity);
        }

        public Task UpdateAsync(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            entities.Update(entity);
            return Task.CompletedTask;

        }
    }
}
