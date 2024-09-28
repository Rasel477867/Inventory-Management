using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryCore
{
    public class Product:AuditableEntity
    {
        [Display(Name ="Product")]
        public string? ProductName { get; set; }
        public string? Description { get; set; }
        public Guid? CategoryId {  get; set; }
        public Category Category { get; set; }
        public decimal Price { get; set; }
        public string? Barcode {  get; set; }
        public int? StockQuantity { get; set; }
        [Display(Name = "Photo")]
        public string? ImageUrl { get; set; }

        [NotMapped]
        public IFormFile? Image { get; set; }

    }
}
