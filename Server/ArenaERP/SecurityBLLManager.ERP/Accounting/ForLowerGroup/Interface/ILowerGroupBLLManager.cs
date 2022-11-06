using ModelClass.ERP.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityBLLManager.ERP.Accounting.ForLowerGroup.Interface
{
    public interface ILowerGroupBLLManager
    {
        Task<bool> Add(AccountGroupLowerViewModel model);
        Task<bool> Update(AccountGroupLowerViewModel model);
        Task<IEnumerable<AccountGroupLowerViewModel>> GetAllAccountGroupLowerrByComp(int compId);
        Task<AccountGroupLowerViewModel> GetAccountGroupLowerById(int Id);
        Task<bool> Delete(int Id);
    }
}
