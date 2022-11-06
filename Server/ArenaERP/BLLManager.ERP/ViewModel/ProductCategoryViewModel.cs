using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelClass.ERP.ViewModel
{
    public class ProductCategoryViewModel
    {
        public int? Id { get; set; }
        public int? ProductId { get; set; }
        public int? CategoryId { get; set; }
        public int? CompId { get; set; }
        public int? BranchId { get; set; }
        public string? ProductName { get; set; }
        public string? ColorName { get; set; }
    }
}
