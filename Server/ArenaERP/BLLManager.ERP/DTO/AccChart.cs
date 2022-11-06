using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelClass.ERP.DTO
{
    public class AccChart
    {
        [Key]
        public int Id { get; set; }
        public int? LowerGroupId { get; set; }
        public int? DetailsId { get; set; }
        public int? GroupAccountId { get; set; }
        public int AccountId { get; set; }
        public int CompId { get; set; }
        public int BranchId { get; set; }
        public string? AccountName { get; set; }
        public string? AccountNo { get; set; }
        public string? AccountNamed { get; set; }
        public string? AliasName { get; set; }
        public decimal? OpenningBalance { get; set; }
        public int? CurrencyId { get; set; }
        public int? AccType { get; set; }
        public int? IsSubledger { get; set; }
        public int? IsBillbyBill { get; set; }
        public int? IsInventory { get; set; }
        public int? IsCostCenter { get; set; }
        public int? HeadGroupId { get; set; }
        public string HeadGroupName { get; set; }
        public int? BalanceType { get; set; }
        public int? IsActive { get; set; }
        public decimal? DepriciationRate { get; set; }
        public int? NoteToHeadId { get; set; }
        public int? AccountGroupId { get; set; }
        public int? IsSalesAccount { get; set; }
        public decimal? CreditLimit { get; set; }
        public decimal? CurrencyRate { get; set; }
        public decimal? FCAcc { get; set; }
        public decimal? FCAmount { get; set; }
        public int? CreditDays { get; set; }
        public int? IsBothBill { get; set; }
        public int? PrintPorder { get; set; }
        public int? DiscountTypeId { get; set; }
        public int? CommissionTypeId { get; set; }
        public int? isFixed { get; set; }
        public int? IsIndependSubledger { get; set; }
        public int? SubLeadeger { get; set; }
        public int? IsEmployee { get; set; }
        public string TIN { get; set; }
        public string BIN { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? Status { get; set; }
        public virtual ICollection<ProductSupplier> ProductSupplier { get; set; }

    }
}
