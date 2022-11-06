using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelClass.ERP.ViewModel
{
    public class ProductColorViewModel
    {
        public int? Id { get; set; }
        public int? ProductId { get; set; }
        public int? ColorId { get; set; }
        public int? CompId { get; set; }
        public string? ProductName { get; set; }
        public string? CategoryName { get; set; }
    }
}
