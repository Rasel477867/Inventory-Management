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
    public class ProductUnitOfWork : UnitOfWork, IProductUnitOfWork
    {
        private readonly ApplicationDbContext _dbcontext;
        public ProductUnitOfWork(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _dbcontext = applicationDbContext;
        }

        public ICategoryRepository CategoryRepository
        {
            get
            {
                return new CategoryRepository(_dbcontext);
            }
        }
    }
}
