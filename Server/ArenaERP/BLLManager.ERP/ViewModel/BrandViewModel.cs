using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelClass.ERP.ViewModel
{
    public class BrandViewModel
    {
        public int Id { get; set; }
        public string BrandName { get; set; }
        public int CompId { get; set; }
        public string Description { get; set; }
        public int? IsActive { get; set; }
        public int? ModuleId { get; set; }
        public int? Status { get; set; }
    }
}
