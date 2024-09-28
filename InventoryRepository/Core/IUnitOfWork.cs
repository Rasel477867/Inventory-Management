using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryRepository.Core
{
    public interface IUnitOfWork
    {
        Task<bool> CompleteAsync();
    }
}
