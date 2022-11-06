using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelClass.ERP.ViewModel;
using SecurityBLLManager.ERP.BrandBLL.Interface;

namespace Services.ERP.Controllers
{
    [Route("api/brand")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandBLLManager _bLLManager;
        private readonly ILogger<BrandController> _logger;
        public BrandController(IBrandBLLManager bLLManager, ILogger<BrandController> logger)
        {
            _bLLManager = bLLManager;
            _logger = logger;
        }


        
        [HttpPost("AddBrand")]
        public async Task<IActionResult> AddBrand([FromBody] BrandViewModel model)
        {
            try
            {
                var result = await _bLLManager.AddBrand(model);
                return Ok(new {status=result.success,result=result.brandId});
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpPost("UpdateBrand")]
        public async Task<IActionResult> UpdateBrand([FromBody] BrandViewModel model)
        {
            try
            {
                var result = await _bLLManager.UpdateBrand(model);
                return Ok(new { status = result.success, result = result.brandId });
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpGet("GetAllBrandByComp/{compId}")]
        public async Task<IActionResult> GetAllBrandByComp( int compId)
        {
            try
            {
                var result = await _bLLManager.GetAllBrandByComp(compId);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpDelete("DeleteBrand/{deleteId}")]
        public async Task<IActionResult> DeleteBrand( int deleteId)
        {
            try
            {
                var result = await _bLLManager.DeleteBrand(deleteId);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpGet("GetBrandById/{id}")]
        public async Task<IActionResult> GetBrandById( int id)
        {
            try
            {
                var result = await _bLLManager.GetBrandById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

    }
}
