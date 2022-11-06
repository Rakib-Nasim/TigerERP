using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelClass.ERP.ViewModel;
using SecurityBLLManager.ERP.IProductBLL.Interface;

namespace Services.ERP.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductBLLManager _bLLManager;

        public ProductController( IProductBLLManager bLLManager)
        {
            _bLLManager = bLLManager;
        }

        [HttpPost ("AddProduct")]
        public async Task<IActionResult>AddProduct(ProductViewModel model)
        {
            try
            {
                bool result = await _bLLManager.AddProduct(model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet("GetProductByComp/{compId}")]
        public async Task<ActionResult<IEnumerable<ProductViewModel>>> GetProductByComp(int compId)
        {
            IEnumerable<ProductViewModel> result=await _bLLManager.GetAllProductByComp(compId);
            return Ok(result);
        }


        [HttpGet("GetAllActiveProductByComp/{compId}")]
        public async Task<ActionResult<IEnumerable<ProductViewModel>>> GetAllActiveProductByComp(int compId)
        {
            IEnumerable<ProductViewModel> result = await _bLLManager.GetAllActiveProductByComp(compId);
            return Ok(result);
        }

    }
}
