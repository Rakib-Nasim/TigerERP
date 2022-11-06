using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelClass.ERP.ViewModel;
using SecurityBLLManager.ERP.Categories.Interface;

namespace Services.ERP.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoriesBLLManager _bLLManager;

        public CategoryController(ICategoriesBLLManager bLLManager)
        {
            _bLLManager = bLLManager;
        }


        [HttpPost("AddCategory")]
        public async Task<IActionResult> AddCategory([FromBody] CategoryViewModel model)
        {
            try
            {
                var result = await _bLLManager.AddCategory(model);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpGet("GetAllCategoryByComp/{compId}")]
        public async Task<IActionResult> GetAllCategoryByComp(int compId)
        {
            try
            {
                var result = await _bLLManager.GetAllCategoryByComp(compId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete("DeleteCategory/{deleteId}")]
        public async Task<IActionResult> DeleteBrand(int deleteId)
        {
            try
            {
                var result = await _bLLManager.DeleteCategory(deleteId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("GetCategoryById/{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            try
            {
                var result = await _bLLManager.GetCategoryById(id); 
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("GetAllProductTypeByComp/{compId}")]
        public async Task<IActionResult> GetAllProductTypeByComp(int compId)
        {
            try
            {
                var result = await _bLLManager.GetAllProductTypeByComp(compId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
