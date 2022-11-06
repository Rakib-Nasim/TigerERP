using ModelClass.ERP.UnitOfWorkRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelClass.ERP.DTO
{
    public class Color:IEntity<int>
    {
        public int Id { get; set; }
        public int ColorId { get; set; }
        public int CompId { get; set; }
        public int? SortOrder { get; set; }
        public int? IsActive { get; set; }
        public int? ModuleId { get; set; }
        public string? ColorName { get; set; }
        public string? Description { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? Status { get; set; }
    }
}
