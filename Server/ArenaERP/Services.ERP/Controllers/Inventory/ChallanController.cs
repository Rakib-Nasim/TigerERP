using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelClass.ERP.ViewModel;
using SecurityBLLManager.ERP.Inventory.Challan.Interface;
using static Common.ERP.Enum;

namespace Services.ERP.Controllers.Inventory
{
    [Route("api/Inventory/Challan")]
    [ApiController]
    public class ChallanController : ControllerBase
    {
        private readonly IChallanBLLManager _bLLManager;

        public ChallanController(IChallanBLLManager bLLManager)
        {
            _bLLManager = bLLManager;
        }


        [HttpPost ("SaveChallan")]
        public async Task<IActionResult> SaveChallan(ChallanViewModel model)
        {
            try
            {
                var result = await _bLLManager.SaveChallan(model);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpGet ("GetChallanNoByComp/compId/{compId}/branchId/{branchId}/challanType/{challanType}")]
        public async Task<IActionResult> GetChallanNoByComp(int compId,int branchId,ChallanType challanType)
        {
            try
            {
                var result = await _bLLManager.GetChallanNoByComp(compId, branchId, challanType);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

    }
}
