using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelClass.ERP.DTO
{
    public class ProductSupplier
    {
        public int ProductSuplierId { get; set; }
        public int ProductId { get; set; }
        public int SupplierId { get; set; }
        public int CompId { get; set; }
        public int BranchId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? Status { get; set; }
        public Product Product { get; set; }
        public AccChart AccChart { get; set; }
    }
}
