using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryCore
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }

        public BaseEntity()
        {
            this.Id = Guid.NewGuid();
            this.IsDeleted = false;
            this.IsActive = true;
        }
    }
}
