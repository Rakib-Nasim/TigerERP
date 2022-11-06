using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelClass.ERP.DTO
{
	public class AccountGroupMid
	{
        [Key]
		public int Id { get; set; }
		public int? MidGroupId { get; set; }
		public int? TopGroupId { get; set; }
		public int? AccountType { get; set; }
		public int? BalanceType { get; set; }
		public string? GroupCode { get; set; }
		public string? GroupName { get; set; }
		public string? Caption { get; set; }
		public int? AccountTypeID { get; set; }
		public int? IsAssets { get; set; }
		public int? AccType { get; set; }
		public int? AccountFlowType { get; set; }
		public int? Effect { get; set; }
		public int? IsBlank { get; set; }
		public int? isTrialBal1 { get; set; }
		public int? TrialBalaAfect { get; set; }
		public string? BalanceShetGrp { get; set; }
		public string? SdateBalancAffect { get; set; }
		public string? BalanceSheetCaption { get; set; }
		public string? BalanceSheetGroupCaption { get; set; }
		public int? PrintOrderTrialBalance { get; set; }
		public int? PrintOrderBalanceSheet { get; set; }
		public int? PrintOrderCashFlow { get; set; }
		public string? FundFlowCaption { get; set; }
		public string? FundFlowGroup { get; set; }
		public int? PrintOrderFundFlow { get; set; }
		public int? PrintOrderIncomeStatement { get; set; }
		public int? PrintOrderProfitLoss { get; set; }
		public int? PrintOrderTrading { get; set; }
		public string? IncomeStateCaption { get; set; }
		public string? IncomeStateCaption2 { get; set; }
		public string? IncomeStateCaption3 { get; set; }
		public string? BalanceForAppropriation { get; set; }
		public int? AppropriationPrintOrder { get; set; }
		public int? IncomeStateCaption4 { get; set; }
		public string? IncomeStateCaption5 { get; set; }
	}
}
