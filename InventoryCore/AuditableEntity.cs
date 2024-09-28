using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryCore
{
    public class AuditableEntity:BaseEntity
    {
        public Guid? LastModifiedBy { get; set; }

        public DateTime? LastModified { get; set; }
        public Guid? CreatedBy { get; set; }

        public DateTime Created { get; set; }


        public AuditableEntity()
        {
            Created = DateTime.Now;
        }
    }
}
