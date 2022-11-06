using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelClass.ERP.ViewModel
{
    public class ModuleViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ModuleRoutePath { get; set; }
        public int? IsActive { get; set; }
        public int? ParentModuleId { get; set; }
        public int? IsParent { get; set; }
        public int? SerialNo { get; set; }
        public string? Image { get; set; }
    }
}
