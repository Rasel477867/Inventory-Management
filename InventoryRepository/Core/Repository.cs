using InventoryCore;
using InventoryRepository.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryRepository.Core
{
    public abstract class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _db;
        public Repository(ApplicationDbContext db)
        {
            _db = db;
        }
        public DbSet<T> table
        {
            get
            {
                return _db.Set<T>();
            }
        }
        public virtual async Task AddAsync(T Entity)
        {

            await table.AddAsync(Entity);

        }

        public virtual async Task DeleteAsync(T Entity)
        {
            await Task.Run(() =>
            {
               
                table.Remove(Entity);

            });
        }

        public  IQueryable<T> GetAllAsync()
        {
            return  table.AsQueryable();
        }

        public virtual async Task<List<T>> GetAllListAsync()
        {
            return await table.Where(x=>!x.IsDeleted).ToListAsync();
        }

        public async Task<T> GetByIdAsyc(Guid id)
        {
            var query =  table.Where(x =>!x.IsDeleted &&  x.Id == id).AsQueryable();

            return await query.AsNoTracking().FirstOrDefaultAsync();
        }

        public virtual async Task UpdateAsync(T Entity)
        {
            await Task.Run(() =>
            {
                table.Update(Entity);

            });

        }
    }
}
