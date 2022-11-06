using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelClass.ERP.ViewModel
{
    public class PageViewModel
    {
        public int Id { get; set; }
        public int ModuleId { get; set; }
        public string Name { get; set; }
        public string PageRoutePath { get; set; }
        public int? SerialNo { get; set; }
        public string? ModuleName { get; set; }
        public int? UserId { get; set; }
        public int? PageId { get; set; }
        public bool? IsAssigned { get; set; }
        public bool? Createable { get; set; }
        public bool? Editable { get; set; }
        public bool? Deleteable { get; set; }
        public int? CompId { get; set; }
        public int? AssignedBy { get; set; }
    }
}
