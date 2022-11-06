using ModelClass.ERP.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityBLLManager.ERP.Accounting.ForMidGroup.Interface
{
    public interface IMidGroupBLLManager
    {
        Task<IEnumerable<AccountGroupMidViewModel>> GetAllGroupMid();
    }
    public interface ITopGroupBLLManager
    {
        Task<IEnumerable<AccountGroupTopViewModel>> GetAllGroupTop();
        Task<IEnumerable<CashFlowViewModel>> GetAllCashflow();
    }
}
