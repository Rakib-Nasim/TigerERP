using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelClass.ERP.ViewModel;
using SecurityBLLManager.ERP.UnitBLLManager.Interface;

namespace Services.ERP.Controllers
{
    [Route("api/Unit")]
    [ApiController]
    public class UnitController : ControllerBase
    {
        private readonly IUnitBLLManager _bLLManager;

        public UnitController(IUnitBLLManager bLLManager)
        {
            _bLLManager = bLLManager;
        }


        [HttpPost("AddUnit")]
        public async Task<IActionResult> AddUnit([FromBody] UnitViewModel model)
        {
            try
            {
                var result = await _bLLManager.AddUnit(model);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpGet("GetAllUnitByComp/{compId}")]
        public async Task<IActionResult> GetAllUnitByComp(int compId)
        {
            try
            {
                var result = await _bLLManager.GetAllUnitByComp(compId);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpDelete("DeleteUnit/{deleteId}")]
        public async Task<IActionResult> DeleteUnit(int deleteId)
        {
            try
            {
                var result = await _bLLManager.DeleteUnit(deleteId);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpGet("GetUnitById/{id}")]
        public async Task<IActionResult> GetUnitById(int id)
        {
            try
            {
                var result = await _bLLManager.GetUnitById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
