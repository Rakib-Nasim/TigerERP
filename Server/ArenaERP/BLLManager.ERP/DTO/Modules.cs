using ModelClass.ERP.UnitOfWorkRepository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelClass.ERP.DTO
{
    public class Modules:IEntity<int>
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
