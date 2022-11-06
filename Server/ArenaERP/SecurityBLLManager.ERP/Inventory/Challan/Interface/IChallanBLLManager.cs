using ModelClass.ERP.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Common.ERP.Enum;

namespace SecurityBLLManager.ERP.Inventory.Challan.Interface
{
    public interface IChallanBLLManager
    {
        Task<(bool IsSaved, int ChallanId)> SaveChallan(ChallanViewModel model);
        Task<int> GetChallanNoByComp(int compId,int branchId, ChallanType challanType);
    }
}
