using ModelClass.ERP.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionLayer.ERP.ForChallanMaster
{
    public interface IChallanMasterBLLManger
    {
        Task<ChallanMasterViewModel> SaveChallanMaster(ChallanMasterViewModel model);
    }
}
