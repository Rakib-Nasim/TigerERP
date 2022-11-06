using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelClass.ERP.DTO
{
	public class AccountGroupTop
	{
        [Key]
		public int TopGroupId { get; set; }
		public string? GroupCode { get; set; }
		public string? GroupName { get; set; }
		public int? AccountType { get; set; }
		public int? BalanceType { get; set; }

	}
}
