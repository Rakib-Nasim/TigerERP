using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelClass.ERP.ViewModel;
using SecurityBLLManager.ERP.IProductSupplierBLL.Interface;

namespace Services.ERP.Controllers
{
    [Route("api/ProductSupplie")]
    [ApiController]
    public class ProductSupplierController : ControllerBase
    {
        private readonly IProductSupplierBLLManager _bLLManager;

        public ProductSupplierController(IProductSupplierBLLManager bLLManager)
        {
            _bLLManager = bLLManager;
        }

        [HttpPost("AddProductSupplier")]

        public async Task<IActionResult>AddProductSupplier(ProductSupplierViewModel model)
        {
            try
            {
                var result = await _bLLManager.AddProductSupplies(model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        [HttpGet("GetAllProductSuppliesComp/{compId}")]
        public async Task<IActionResult> GetAllProductSuppliesComp(int compId)
        {
            try
            {
                var result = await _bLLManager.GetAllProductSuppliesComp(compId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
