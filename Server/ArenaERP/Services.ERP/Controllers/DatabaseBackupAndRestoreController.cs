using Common.ERP;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SecurityBLLManager.ERP.ForDatabaseBackup.Interface;

namespace Services.ERP.Controllers
{
    [Route("api/database")]
    [ApiController]
    public class DatabaseBackupAndRestoreController : ControllerBase
    {
        private readonly IDatabaseBackupAndRestoreBLLManager _bLLManager;
        private readonly IConfiguration _config;

        public DatabaseBackupAndRestoreController(IDatabaseBackupAndRestoreBLLManager bLLManager, IConfiguration config)
        {
            _bLLManager = bLLManager;
            _config = config;
        }


        [HttpGet]
        public async Task< IActionResult> BackupDb()
        {
            Response response = new Response();
            try
            {
                string filePath =await _bLLManager.DatabaseBackup( _config["SqlServer:Database"], _config["Directory:DatabaseFilePath"]);
                response.Status = (filePath == null) ? false : true;
                response.Result = filePath;
                return Ok(response);
            }
            catch (Exception err)
            {
                response.Status = false;
                response.Result = err.Message;
                return Ok(response);
            }
        }
    }
}
