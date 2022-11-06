using AutoMapper;
using Common.ERP.UtilityManagement;
using Infrustracture.ERP.UnitOfWorkSetup.ForChallan.ForChallanMaster;
using ModelClass.ERP.DTO;
using ModelClass.ERP.ViewModel;
using static Common.ERP.Enum;

namespace OnionLayer.ERP.ForChallanMaster
{
    public class ChallanMasterBLLManger : IChallanMasterBLLManger
    {
        private readonly IChallanMasterUnitOfWork _challanunitOfWork;
        private readonly IMapper _mapper;

        public ChallanMasterBLLManger(IChallanMasterUnitOfWork challanunitOfWork,IMapper mapper)
        {
            _challanunitOfWork = challanunitOfWork;
            _mapper = mapper;
        }

        public async Task<ChallanMasterViewModel> SaveChallanMaster(ChallanMasterViewModel model)
        {
            int ChallanId = 0;
            int ChallanNo = 0;
            ChallanMaster masterData = new ChallanMaster();
            if (model.NatureId == 1 || model.NatureId == 4 || model.NatureId == 49 || model.NatureId == 5)
            {
                model.ChallanType = "DC";
            }
            else if (model.NatureId == 2 || model.NatureId == 3 || model.NatureId == 50)
            {
                model.ChallanType = "RC";

            }
            else if (model.NatureId == 51)
            {
                model.ChallanType = "CM";

            }
            else if (model.NatureId == 8)
            {
                model.ChallanType = "WR";
            }
            else
            {
                model.ChallanType = "NO";
            }

            ChallanId = CustomValidation.MaxNumber<int>("ChallanMaster", "ChallanId", "CompId", model.CompId);
            model.ChallanId = ChallanId + 1;

            ChallanNo = CustomValidation.MaxNumberForThreeParemeter<int>("ChallanMaster", "ChallanNo", "CompId", model.CompId, "BranchId", model.BranchId, "ChallanType", model.ChallanType);
            model.ChallanNo = ChallanNo + 1;
            if (model.Id == 0 || model.Id == null)
            {
                masterData = new ChallanMaster();
                masterData.CreatedBy = "Bappy";
                masterData.CreatedDate = DateTime.Now;
                masterData.Status = (int)AvailableStatus.Active;
                await _challanunitOfWork.ChallanMaster.AddAsync(masterData);
            }
            masterData = _mapper.Map(model, masterData);
            return model;
        }
    }
}
