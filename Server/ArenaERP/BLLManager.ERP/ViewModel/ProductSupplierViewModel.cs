using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelClass.ERP.ViewModel
{
    public class ProductSupplierViewModel
    {
        public int ProductSupplierId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int AccountId { get; set; }
        public string AccountName { get; set; }
        public int CompId { get; set; }
        public int BranchId { get; set; }
    }
}
