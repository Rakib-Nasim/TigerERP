using AutoMapper;
using Common.ERP.UtilityManagement;
using DatabaseContext;
using Infrustracture.ERP.UnitOfWorkSetup.ForChallan.ForChallanDetails;
using Infrustracture.ERP.UnitOfWorkSetup.ForChallan.ForChallanMaster;
using Microsoft.EntityFrameworkCore;
using ModelClass.ERP.DTO;
using ModelClass.ERP.ViewModel;
using OnionLayer.ERP.ForChallanDetails;
using OnionLayer.ERP.ForChallanMaster;
using SecurityBLLManager.ERP.Inventory.Challan.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Common.ERP.Enum;

namespace SecurityBLLManager.ERP.Inventory.Challan.Logic
{
    public class ChallanBLLManager : IChallanBLLManager
    {
        private readonly IChallanMasterUnitOfWork _challanunitOfWork;
        private readonly IChallanDetailsUnitOfWork _challandetailsunitOfWork;
        private readonly IMapper _mapper;
        private readonly IChallanMasterBLLManger _challanMasterBLL;
        private readonly IChallanDetailsBLLManger _challanDetails;

        public ChallanBLLManager(
            IChallanMasterUnitOfWork challanunitOfWork,
            IChallanDetailsUnitOfWork challandetailsunitOfWork,
            IMapper mapper,
            IChallanMasterBLLManger challanMasterBLL,
            IChallanDetailsBLLManger challanDetails)
        {
            _challanunitOfWork = challanunitOfWork;
            _challandetailsunitOfWork = challandetailsunitOfWork;
            _mapper = mapper;
            _challanMasterBLL = challanMasterBLL;
            _challanDetails = challanDetails;
        }

        #region Save Challan
        public async Task<(bool IsSaved, int ChallanId)> SaveChallan(ChallanViewModel model)
        {
            if (model.ChallanDetails.Count == 0)
            {
                throw new Exception("No Product found!");
            }

            try
            {
                await _challanunitOfWork.BeginTransactionAsync();
                bool IsSuccess = false;

                var challanMaster  =await _challanMasterBLL.SaveChallanMaster(model.ChallanMaster);
                var challanDetails = await _challanDetails.SaveChallanDeatils(model.ChallanDetails, model.ChallanMaster);

                var result = await _challanunitOfWork.SaveAsync();
                await _challanunitOfWork.CommitTransactionAsync();
                return (result, model.ChallanMaster.ChallanId);

            }
            catch (Exception ex)
            {
                await _challanunitOfWork.RollbackTransactionAsync();
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region GetChallan No

        public async Task<int> GetChallanNoByComp(int compId, int branchId, ChallanType challanType)
        {
            string type = "";
            switch (challanType)
            {
                case ChallanType.Delivery:
                    type = "DC";
                    break;
                case ChallanType.Receive:
                    type = "RC";
                    break;
                case ChallanType.DeliveryReturn:
                    type = "RC";
                    break;
                case ChallanType.ReceiveReturn:
                    type = "DC";
                    break;
                case ChallanType.Transfer:
                    type = "TC";
                    break;
                case ChallanType.Manufacture:
                    type = "MC";
                    break;
                case ChallanType.Consumption:
                    type = "CM";
                    break;

                case ChallanType.WReceive:
                    type = "WR";
                    break;

                default:
                    throw new Exception("Invalid Challan Type");
            }
            int ChallanNo = CustomValidation.MaxNumberForThreeParemeter<int>("ChallanMaster", "ChallanNo", "CompId",compId, "BranchId", branchId, "ChallanType", type);
            return ChallanNo +1;

        }
        #endregion
    }
}
