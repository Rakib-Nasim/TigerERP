using ModelClass.ERP.UnitOfWorkRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelClass.ERP.DTO
{
    public class Godown:IEntity<int>
    {
        public int Id { get; set; }
        public int? GodownId { get; set; }
        public int BranchId { get; set; }
        public int CompId { get; set; }
        public int? IsParent { get; set; }
        public int? ParentId { get; set; }
        public int? LayerId { get; set; }
        public string GodownName { get; set; }
        public string? GodownLocation { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? Status { get; set; }
    }
}
