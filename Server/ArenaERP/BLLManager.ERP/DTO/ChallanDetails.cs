using ModelClass.ERP.UnitOfWorkRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelClass.ERP.DTO
{
    public class ChallanDetails:IEntity<int>
    {
        public int Id { get; set; }
        public int? PartyId { get; set; }
        public int? ChallanId { get; set; }
        public int? ChallanNo { get; set; }
        public string? ChallanType { get; set; }
        public string? ChallanDate { get; set; }
        public int? ProductId { get; set; }
        public int? UnitId { get; set; }
        public decimal? UnitQty { get; set; }
        public decimal? PcsQty { get; set; }
        public decimal? UniqueQty{ get; set; }
        public int? CompId { get; set; }
        public int? BranchId { get; set; }
        public int? GodownId { get; set; }
        public int? ChallanNatureId { get; set; }
        public int? TransId { get; set; }
        public int? OrderId { get; set; }
        public string? ProductionDate { get; set; }
        public string? PDescription { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal? UniquePrice { get; set; }
        public int? RefAutoId { get; set; }
        public string? Remarks { get; set; }
        public int? DestinationGownId { get; set; }
        public decimal? BoxConv { get; set; }
        public decimal? Factor { get; set; }
        public int? QuoteId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? Status { get; set; }

    }
}
