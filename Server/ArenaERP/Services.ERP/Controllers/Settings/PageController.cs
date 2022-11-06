using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelClass.ERP.ViewModel;
using SecurityBLLManager.ERP.LoggerBLLManager;
using SecurityBLLManager.ERP.Settings.ForPage.Interface;

namespace Services.ERP.Controllers.Settings
{
    [Route("api/page")]
    [ApiController]
    public class PageController : ControllerBase
    {
        private readonly ILogger<PageController> _logger;
        private readonly IPageBLLManager _pageBLLManager;
        private readonly ILoggerBLLManager _loggerBLLManager;

        public PageController(ILogger<PageController> logger,
                                IPageBLLManager pageBLLManager,
                                ILoggerBLLManager loggerBLLManager)
        {
            _logger = logger;
            _pageBLLManager = pageBLLManager;
            _loggerBLLManager = loggerBLLManager;
        }

        [HttpPost("AddPage")]
        public async Task<IActionResult> AddPage([FromBody] PageViewModel model)
        {
            try
            {
                var result = await _pageBLLManager.AddPage(model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                await _loggerBLLManager.SaveErrorLog(ex);
                _logger.LogError(ex.Message, ex);
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("GetAllPage")]
        public async Task<IActionResult> GetAllPage()
        {
            try
            {
                var result = await _pageBLLManager.GetAllPage();
                return Ok(result);
            }
            catch (Exception ex)
            {
                await _loggerBLLManager.SaveErrorLog(ex);
                _logger.LogError(ex.Message, ex);

                throw new Exception(ex.Message);
            }
        }

        [HttpPut("UpdatePage")]
        public async Task<IActionResult> UpdatePage([FromBody] PageViewModel model)
        {
            try
            {
                var result = await _pageBLLManager.Update(model);

                return Ok(result);
            }
            catch (Exception ex)
            {
                await _loggerBLLManager.SaveErrorLog(ex);
                _logger.LogError(ex.Message, ex);

                throw new Exception(ex.Message);
            }
        }

        [HttpGet("GetPageById/{id}")]
        public async Task<IActionResult> GetPageById(int id)
        {
            try
            {
                var result = await _pageBLLManager.GetPageById(id);
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
