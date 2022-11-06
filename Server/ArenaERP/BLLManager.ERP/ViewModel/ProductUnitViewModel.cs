using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelClass.ERP.ViewModel
{
    public class ProductUnitViewModel
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public string? ProductName { get; set; }
        public int? UnitId { get; set; }
        public string? UnitName { get; set; }
        public decimal Factor { get; set; }
        public int? CompId { get; set; }
        public int? IsDefaultBillUnit { get; set; }
        public int? IsDefaultChallanUnit { get; set; }
    }
}
