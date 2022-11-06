using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SecurityBLLManager.ERP.Accounting.ForMidGroup.Interface;

namespace Services.ERP.Controllers.Accounting
{
    [Route("api/AccountGroup")]
    [ApiController]
    public class AccountGroupController : ControllerBase
    {
        private readonly IMidGroupBLLManager _midGroupBLL;
        private readonly ITopGroupBLLManager _topGroupBLL;

        public AccountGroupController(IMidGroupBLLManager midGroupBLL, ITopGroupBLLManager topGroupBLL)
        {
            _midGroupBLL = midGroupBLL;
            _topGroupBLL = topGroupBLL;
        }


        [HttpGet("GetAllGroupMid")]
        public async Task<IActionResult> GetAllGroupMid()
        {
            try
            {
                var result = await _midGroupBLL.GetAllGroupMid();
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        [HttpGet("GetAllGroupTop")]
        public async Task<IActionResult> GetAllGroupTop()
        {
            try
            {
                var result = await _topGroupBLL.GetAllGroupTop();
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("GetAllCashFlow")]
        public async Task<IActionResult> GetAllCashFlow()
        {
            try
            {
                var result = await _topGroupBLL.GetAllCashflow();
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
