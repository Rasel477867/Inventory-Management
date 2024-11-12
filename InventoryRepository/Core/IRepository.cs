using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InventoryRepository.Core
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetById(Guid id);
        Task<List<T>> GetAll();
        Task Update(T Entity);
        Task Delete(Guid id);
        Task Add(T Entity);
        IQueryable<T> GetAllAsync();


    }
}
