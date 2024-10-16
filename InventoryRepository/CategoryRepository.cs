using InventoryCore;
using InventoryRepository.Contacts;
using InventoryRepository.Core;
using InventoryRepository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryRepository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _dbcontext;
        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            _dbcontext = db;
        }
    }
}
