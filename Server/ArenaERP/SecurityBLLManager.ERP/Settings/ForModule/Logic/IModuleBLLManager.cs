using ModelClass.ERP.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityBLLManager.ERP.Settings.ForModule.Logic
{
    public interface IModuleBLLManager
    {
        Task<bool> AddModule(ModuleViewModel model);
        Task<bool> Update(ModuleViewModel model);
        Task<IEnumerable<ModuleViewModel>> GetAllModule();
        Task<ModuleViewModel> GetModuleById(int Id);
        Task<IEnumerable<UserModuleViewModel>> GetSubModuleWithPage(int userId, int companyId, int logedUserId, int moduleId = -1);
    }
}
