using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelClass.ERP.ViewModel
{
    public class BranchViewModel
    {
        public int Id { get; set; }
        public int BranchId { get; set; }
        public int CompId { get; set; }
        public string Name { get; set; }
        public string? ShortName { get; set; }
        public string? ContactNo { get; set; }
        public string? Address { get; set; }
        public int? CriteriaId { get; set; }
        public int? Type { get; set; }
        public int? Status { get; set; }
    }
}
