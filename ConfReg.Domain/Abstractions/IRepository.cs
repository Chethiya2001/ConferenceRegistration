using ConfReg.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfReg.Domain.Abstractions
{
    public interface IRepository<T> where T: BaseEntity
    {
        Task<IList<T>> GetAllAsync();
        Task<T> GetByIdAsync(object id);
        Task<bool> IsExist(long id);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        void Remove(T entity);

    }
}
