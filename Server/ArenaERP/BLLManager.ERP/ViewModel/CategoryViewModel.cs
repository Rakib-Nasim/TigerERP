using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelClass.ERP.ViewModel
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public string? ParentCategoryName { get; set; }
        public string? Description { get; set; }
        public int? ParentId { get; set; }
        public int? IsParent { get; set; }
        public int CompId { get; set; }
        public int? ProductType { get; set; }
        public int? ProductionLevel { get; set; }
        public int? IsProduction { get; set; }
        public int? Status { get; set; }
    }
}
