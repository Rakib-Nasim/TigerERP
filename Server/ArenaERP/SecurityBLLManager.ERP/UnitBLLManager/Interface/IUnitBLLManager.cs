using ModelClass.ERP.DTO;
using ModelClass.ERP.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityBLLManager.ERP.UnitBLLManager.Interface
{
    public interface IUnitBLLManager
    {
        Task<bool> AddUnit(UnitViewModel model);
        Task<IEnumerable<UnitViewModel>> GetAllUnitByComp(int compId);
        Task<UnitViewModel> GetUnitById(int Id);
        Task<bool> DeleteUnit(int Id);
    }
}
