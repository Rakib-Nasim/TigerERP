 using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelClass.ERP.ViewModel;
using SecurityBLLManager.ERP.IBranchService.Interface;
using SecurityBLLManager.ERP.LoggerBLLManager;

namespace Services.ERP.Controllers
{
    [Route("api/Branch")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly IBranchServiceBLLManager _branchServiceBLL;
        private readonly ILoggerBLLManager _loggerBLLManager;
        private readonly ILogger<BranchController> _logger;

        public BranchController(ILogger<BranchController> logger,
                                IBranchServiceBLLManager branchServiceBLL,
                                ILoggerBLLManager loggerBLLManager
                                )
        {
            _logger = logger;
            _branchServiceBLL = branchServiceBLL;
            _loggerBLLManager = loggerBLLManager;
        }

        
        [HttpPost("AddBranch")]
        public async Task<IActionResult> AddBranch([FromBody] BranchViewModel model)
        {
            try
            {
                var result = await _branchServiceBLL.AddBranch(model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                await _loggerBLLManager.SaveErrorLog(ex);
                _logger.LogError(ex.Message,ex);
                throw new Exception(ex.Message);

            }
        }

        [HttpGet("GetAllBranchByComp/{compId}")]
        public async Task<IActionResult> GetAllBranchByComp(int compId)
        {
            try
            {
                var result = await _branchServiceBLL.GetAllBranchByComp(compId);
                return Ok(new { status = true, response = result });
            }
            catch (Exception ex)
            {
                await _loggerBLLManager.SaveErrorLog(ex);
                throw new Exception(ex.Message);
            }
        }

        [HttpPut("UpdateBranch")]
        public async Task<IActionResult> UpdateBranch([FromBody] BranchViewModel model)
        {
            try
            {
                var result = await _branchServiceBLL.Update(model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                await _loggerBLLManager.SaveErrorLog(ex);
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete("DeleteBranch/{deleteId}")]
        public async Task<IActionResult> DeleteBranch(int deleteId)
        {
            try
            {
                var result = await _branchServiceBLL.DeleteBranch(deleteId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                await _loggerBLLManager.SaveErrorLog(ex);
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("GetBranchById/{id}")]
        public async Task<IActionResult> GetBranchById(int id)
        {
            try
            {
                var result = await _branchServiceBLL.GetBranchById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                await _loggerBLLManager.SaveErrorLog(ex);
                throw new Exception(ex.Message);
            }
        }

    }
}
