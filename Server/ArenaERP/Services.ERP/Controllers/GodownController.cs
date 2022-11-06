using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelClass.ERP.ViewModel;
using SecurityBLLManager.ERP.IGodownBLLManage.Interface;

namespace Services.ERP.Controllers
{
    [Route("api/Godown")]
    [ApiController]
    public class GodownController : ControllerBase
    {
        private readonly IGodownBLLManager _bLLManager;

        public GodownController(IGodownBLLManager bLLManager)
        {
            _bLLManager = bLLManager;
        }



        
        [HttpPost("AddGodown")]
        public async Task<IActionResult> AddGodown([FromBody] GodownViewModel model)
        {
            try
            {
                var result = await _bLLManager.AddGodown(model);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpGet("GetAllGodownByComp/{compId}")]
        public async Task<IActionResult> GetAllGodownByComp(int compId)
        {
            try
            {
                var result = await _bLLManager.GetAllGodownByComp(compId);
                return Ok(new { status = true, response = result });
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpDelete("DeleteGodown/{deleteId}")]
        public async Task<IActionResult> DeleteGodown(int deleteId)
        {
            try
            {
                var result = await _bLLManager.DeleteGodown(deleteId);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpGet("GetGodownById/{id}")]
        public async Task<IActionResult> GetGodownById(int id)
        {
            try
            {
                var result = await _bLLManager.GetGodownById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

    }
}
