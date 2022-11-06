using ModelClass.ERP.UnitOfWorkRepository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelClass.ERP.DTO
{
	public class AccountGroupLower:IEntity<int>
	{
        [Key]
		public int Id { get; set; }	
		public int LowerGroupId { get; set; }
		public int? MidGroupId { get; set; }
		public string? GroupName { get; set; } 
		public int CompId { get; set; }
		public string? GroupNameAlias { get; set; }
		public string? GroupNameAliasSaikat { get; set; }
		public decimal? Amount { get; set; }
		public int? AccType { get; set; }
		public string? BalancesheetCaption { get; set; }
		public string? ProfitLossCaption { get; set; }
		public string? FundFlowCaption { get; set; }
		public int? AccountType { get; set; }
		public int? BalanceType { get; set; }
		public int? BalancesheetPrintOrder { get; set; }
		public int? IsActive { get; set; }
		public int? isBank { get; set; }
		public int? iSBankCash { get; set; }
		public int? PrintorderGroup { get; set; }
		public int? CashFlowId { get; set; }
		public int? CashFlowPO { get; set; }
		public int? TrailBalancePrintOrder { get; set; }
		public int? ParentId { get; set; }
		public int? IsParent { get; set; }
		public string? BalNotes { get; set; }
		public string? IncomeNotes { get; set; }
		public string? NotesAccounts { get; set; }
		public string? NotesCaption { get; set; }
	}
}
