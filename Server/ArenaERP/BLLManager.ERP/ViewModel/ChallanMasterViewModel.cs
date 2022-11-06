using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelClass.ERP.ViewModel
{
    public class ChallanMasterViewModel
    {
        public int Id { get; set; }
        public int ChallanId { get; set; }
        public int ChallanNo { get; set; }
        public int CompId { get; set; }
        public int BranchId { get; set; }
        public int? SalesPersonId { get; set; }
        public int? PartyId { get; set; }
        public int? NatureId { get; set; }
        public int? RefId { get; set; }
        public int? TransportId { get; set; }
        public string? DeliveryLocation { get; set; }
        public string? Note { get; set; }
        public string? BillTo { get; set; }
        public string? ContactNo { get; set; }
        public string? DriverName { get; set; }
        public string? PartyName { get; set; }
        public string? DriverContactNo { get; set; }
        public string? RefNo { get; set; }
        public string? TransPortName { get; set; }
        public string? ChallanType { get; set; }
    }
}
