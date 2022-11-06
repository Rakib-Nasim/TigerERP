using ModelClass.ERP.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionLayer.ERP.ForChallanDetails
{
    public interface IChallanDetailsBLLManger
    {
        Task <List<ChallanDetailsViewModel>> SaveChallanDeatils(List<ChallanDetailsViewModel> model , ChallanMasterViewModel challanMaster);

    }
}
