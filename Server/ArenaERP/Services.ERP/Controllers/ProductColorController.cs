using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelClass.ERP.ViewModel;
using SecurityBLLManager.ERP.ProductColorBLLMana.Interface;

namespace Services.ERP.Controllers
{
    [Route("api/color")]
    [ApiController]
    public class ProductColorController : ControllerBase
    {
        private readonly IProductColorBLLManager _bLLManager;

        public ProductColorController(IProductColorBLLManager bLLManager)
        {
            _bLLManager = bLLManager;
        }


        //Amran
        [HttpPost("AddColor")]
        public async Task<IActionResult> AddColor([FromBody] ColorViewModel model)
        {
            try
            {
                var result = await _bLLManager.AddProductColor(model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("GetAllColorByComp/{compId}")]
        public async Task<IActionResult> GetAllColorByComp(int compId)
        {
            try
            {
                var result = await _bLLManager.GetAllColorByComp(compId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete("deleteColor/{deleteId}")]
        public async Task<IActionResult> DeleteColor(int deleteId)
        {
            try
            {
                var result = await _bLLManager.DeleteColor(deleteId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("GetColorById/{id}")]
        public async Task<IActionResult> GetColorById(int id)
        {
            try
            {
                var result = await _bLLManager.GetColorById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
