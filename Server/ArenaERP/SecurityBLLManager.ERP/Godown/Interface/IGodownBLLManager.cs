using ModelClass.ERP.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityBLLManager.ERP.IGodownBLLManage.Interface
{
    public interface IGodownBLLManager
    {
        Task<bool> AddGodown(GodownViewModel model);
        Task<IEnumerable<GodownViewModel>> GetAllGodownByComp(int compId);
        Task<GodownViewModel> GetGodownById(int Id);
        Task<bool> DeleteGodown(int Id);
    }
}
