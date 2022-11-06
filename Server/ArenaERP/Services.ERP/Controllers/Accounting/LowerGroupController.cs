using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelClass.ERP.ViewModel;
using SecurityBLLManager.ERP.Accounting.ForLowerGroup.Interface;
using SecurityBLLManager.ERP.LoggerBLLManager;

namespace Services.ERP.Controllers.Accounting
{
    [Route("api/LowerGroup")]
    [ApiController]
    public class LowerGroupController : ControllerBase
    {
        private readonly ILowerGroupBLLManager _lowerGroupBLL;
        private readonly ILogger<LowerGroupController> _logger;
        private readonly ILoggerBLLManager _loggerBLLManager;

        public LowerGroupController(ILowerGroupBLLManager lowerGroupBLL,
                                    ILogger<LowerGroupController> logger,
                                    ILoggerBLLManager loggerBLLManager)
        {
            _lowerGroupBLL = lowerGroupBLL;
            _logger = logger;
            _loggerBLLManager = loggerBLLManager;
        }


        [HttpPost("AddLowerGroup")]
        public async Task<IActionResult> AddLowerGroup([FromBody] AccountGroupLowerViewModel model)
        {
            try
            {
                var result = await _lowerGroupBLL.Add(model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                await _loggerBLLManager.SaveErrorLog(ex);
                _logger.LogError(ex.Message, ex);
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("GetAllAccountGroupLowerrByComp")]
        public async Task<IActionResult> GetAllAccountGroupLowerrByComp(int compId)
        {
            try
            {
                var result = await _lowerGroupBLL.GetAllAccountGroupLowerrByComp(compId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
