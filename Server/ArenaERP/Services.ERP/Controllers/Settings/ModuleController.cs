using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelClass.ERP.ViewModel;
using SecurityBLLManager.ERP.LoggerBLLManager;
using SecurityBLLManager.ERP.Settings.ForModule.Logic;

namespace Services.ERP.Controllers.Settings
{
    [Route("api/Module")]
    [ApiController]
    public class ModuleController : ControllerBase
    {
        private readonly ILogger<ModuleController> _logger;
        private readonly IModuleBLLManager _moduleBLLManager;
        private readonly ILoggerBLLManager _loggerBLLManager;

        public ModuleController(ILogger<ModuleController> logger,
                                IModuleBLLManager moduleBLLManager ,
                                ILoggerBLLManager loggerBLLManager)
        {
            _logger = logger;
            _moduleBLLManager = moduleBLLManager;
            _loggerBLLManager = loggerBLLManager;
        }

        [HttpPost("AddModule")]
        public async Task<IActionResult> AddModule([FromBody] ModuleViewModel model)
        {
            try
            {
                var result = await _moduleBLLManager.AddModule(model);

                return Ok(result);
            }
            catch (Exception ex)
            {
                await _loggerBLLManager.SaveErrorLog(ex);
                _logger.LogError(ex.Message, ex);
                throw new Exception(ex.Message);

            }
        }

        [HttpGet("GetAllModule")]
        public async Task<IActionResult> GetAllModule()
        {
            try
            {
                var result = await _moduleBLLManager.GetAllModule();
                return Ok(result);
            }
            catch (Exception ex)
            {
                await _loggerBLLManager.SaveErrorLog(ex);
                _logger.LogError(ex.Message, ex);

                throw new Exception(ex.Message);
            }
        }

        [HttpPut("UpdateModule")]
        public async Task<IActionResult> UpdateModule([FromBody] ModuleViewModel model)
        {
            try
            {
                var result = await _moduleBLLManager.Update(model);

                return Ok(result);
            }
            catch (Exception ex)
            {
                await _loggerBLLManager.SaveErrorLog(ex);
                _logger.LogError(ex.Message, ex);

                throw new Exception(ex.Message);
            }
        }
        
        [HttpGet("GetModuleById/{id}")]
        public async Task<IActionResult> GetModuleById(int id)
        {
            try
            {
                var result = await _moduleBLLManager.GetModuleById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                await _loggerBLLManager.SaveErrorLog(ex);
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("GetSubModuleWithPage/{userId}/{companyId}/{logedUserId}/{moduleId}")]
        public async Task<IActionResult> GetSubModuleWithPage(int userId, int companyId, int logedUserId, int moduleId = -1)
        {
            try
            {
                var result = await _moduleBLLManager.GetSubModuleWithPage(userId,companyId,logedUserId,moduleId);
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
