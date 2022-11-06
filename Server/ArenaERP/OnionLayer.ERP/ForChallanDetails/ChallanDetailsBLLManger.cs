using AutoMapper;
using Common.ERP.UtilityManagement;
using Infrustracture.ERP.UnitOfWorkSetup.ForChallan.ForChallanDetails;
using ModelClass.ERP.DTO;
using ModelClass.ERP.ViewModel;
using static Common.ERP.Enum;

namespace OnionLayer.ERP.ForChallanDetails
{
    public class ChallanDetailsBLLManger : IChallanDetailsBLLManger
    {
        private readonly IChallanDetailsUnitOfWork _challanunitOfWork;
        private readonly IMapper _mapper;

        public ChallanDetailsBLLManger(IChallanDetailsUnitOfWork challanunitOfWork, IMapper mapper)
        {
            _challanunitOfWork = challanunitOfWork;
            _mapper = mapper;
        }
        public async Task<List<ChallanDetailsViewModel>> SaveChallanDeatils(List<ChallanDetailsViewModel> model, ChallanMasterViewModel challanMaster)
        {
            sbyte multiplier = (sbyte)(challanMaster.ChallanType == "DC" ? -1 : 1);
            int totalPrice = 0;
            int totalQty = 0;
            int unitPrice = 0;
            ChallanDetails ChallanDetails = new ChallanDetails();
            foreach (ChallanDetailsViewModel data in model)
            {
                if (data.Id == 0 || data.Id == null)
                {
                    ChallanDetails = new ChallanDetails();
                    ChallanDetails.CreatedBy = "Bappy";
                    ChallanDetails.CreatedDate = DateTime.Now;
                    ChallanDetails.Status = (int)AvailableStatus.Active;
                    await _challanunitOfWork.ChallanDetails.AddRangeAsync(ChallanDetails);
                }
                data.ChallanId = challanMaster.ChallanId;
                data.ChallanNo = challanMaster.ChallanNo;
                data.ChallanType = challanMaster.ChallanType;
                data.CompId = challanMaster.CompId;
                data.BranchId = challanMaster.BranchId;
                data.PcsQty = data.PcsQty * multiplier;
                data.UnitQty = data.UnitQty * multiplier;
                data.UniqueQty = (data.UnitQty * data.Factor) + data.PcsQty;
                if (challanMaster.ChallanType == "DC")
                {
                    totalPrice = CustomValidation.SumForUniquePriceAndQty<int>("ChallanDetail", "UniquePrice", "ProductId", data.ProductId, "CompId", data.CompId, "BranchId", data.BranchId);
                    totalQty = CustomValidation.SumForUniquePriceAndQty<int>("ChallanDetail", "UniqueQty", "ProductId", data.ProductId, "CompId", data.CompId, "BranchId", data.BranchId);
                    unitPrice = totalPrice / totalQty;
                }
                data.UnitPrice = unitPrice > 0 ? unitPrice : data.UnitPrice;
                data.UniquePrice = (data.UnitPrice * data.UniqueQty);
                ChallanDetails = _mapper.Map(data, ChallanDetails);

            }

            return model;

        }
    }
}
