using ModelClass.ERP.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityBLLManager.ERP.IBranchService.Interface
{
    public interface IBranchServiceBLLManager
    {
        Task<bool> AddBranch(BranchViewModel model);
        Task<bool> Update(BranchViewModel model);
        Task<IEnumerable<BranchViewModel>> GetAllBranchByComp(int compId);
        Task<BranchViewModel> GetBranchById(int Id);
        Task<bool> DeleteBranch(int Id);
    }
}
