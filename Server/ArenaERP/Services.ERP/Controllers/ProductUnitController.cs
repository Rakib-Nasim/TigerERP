using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelClass.ERP.ViewModel;
using SecurityBLLManager.ERP.IProductUnitConvBLL.Interface;

namespace Services.ERP.Controllers
{
    [Route("api/ProductUnit")]
    [ApiController]
    public class ProductUnitController : ControllerBase
    {
        private readonly IProductUnitConvBLLManager _bLLManager;

        public ProductUnitController(IProductUnitConvBLLManager bLLManager)
        {
            _bLLManager = bLLManager;
        }


        [HttpPost("AddProductUnit")]
        public async Task<IActionResult> AddProductUnit([FromBody] ProductUnitViewModel model)
        {
            try
            {
                var result = await _bLLManager.AddProductUnit(model);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpGet("GetAllProductUnitByComp/{compId}")]
        public async Task<IActionResult> GetAllProductUnitByComp(int compId)
        {
            try
            {
                var result = await _bLLManager.GetAllProductUnitByComp(compId);
                return Ok(new { statu = true, response = result });
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpGet("DeleteProductUnit/{deleteId}")]
        public async Task<IActionResult> DeleteProductUnit(int deleteId)
        {
            try
            {
                var result = await _bLLManager.DeleteProductUnit(deleteId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("GetProductUnitById/{id}")]
        public async Task<IActionResult> GetProductUnitById(int id)
        {
            try
            {
                var result = await _bLLManager.GetProductUnitById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
