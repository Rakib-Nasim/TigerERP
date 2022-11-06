using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelClass.ERP.ViewModel;
using SecurityBLLManager.ERP.IProductCategoryBLL.Interface;

namespace Services.ERP.Controllers
{
    [Route("api/ProductCategory")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        private readonly IProductCategoryBLLManager _bLLManager;
        public ProductCategoryController(IProductCategoryBLLManager bLLManager)
        {
            _bLLManager = bLLManager;
        }


        [HttpPost("AddProductCategory")]
        public async Task<IActionResult> AddProductCategory([FromBody] ProductCategoryViewModel model)
        {
            try
            {
                var result = await _bLLManager.AddProductCategory(model);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpGet("GetAllProductCategoryByComp/{compId}")]
        public async Task<IActionResult> GetAllProductCategoryByComp(int compId)
        {
            try
            {
                var result = await _bLLManager.GetAllProductCategoryByComp(compId);
                return Ok(new { statu = true, response = result });
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpGet("DeleteProductCategory/{deleteId}")]
        public async Task<IActionResult> DeleteProductCategory(int deleteId)
        {
            try
            {
                var result = await _bLLManager.DeleteProductCategory(deleteId);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpGet("GetProductCategoryById/{id}")]
        public async Task<IActionResult> GetProductCategoryById(int id)
        {
            try
            {
                var result = await _bLLManager.GetProductCategoryById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
