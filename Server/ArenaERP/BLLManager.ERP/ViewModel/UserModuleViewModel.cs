using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelClass.ERP.ViewModel
{
    public class UserModuleViewModel
    {
        public int? Id { get; set; }
        public int ModuleId { get; set; }
        public string Name { get; set; }
        public string ModuleRoutePath { get; set; }
        public int? ParentModuleID { get; set; }
        public bool IsAssigned { get; set; }
        public int? IsParent { get; set; }
        public int? SerialNo { get; set; }
        public List<PageViewModel> Pages { get; set; }
        public List<UserModuleViewModel> SubModules { get; set; }
        public int CompId { get; set; }
    }
}
