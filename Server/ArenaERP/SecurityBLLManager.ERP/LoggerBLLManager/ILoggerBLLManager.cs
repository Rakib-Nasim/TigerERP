
using DatabaseContext;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using ModelClass.ERP.DTO;
using ModelClass.ERP.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SecurityBLLManager.ERP.LoggerBLLManager
{
    public interface ILoggerBLLManager
    {
        Task<bool>SaveErrorLog(Exception model);
    }

    public class LoggerBLLManager : ILoggerBLLManager
    {
        private readonly DatabaseContextDb _contextDb;

        public LoggerBLLManager(DatabaseContextDb contextDb)
        {
            _contextDb = contextDb;
        }

        public async Task<bool> SaveErrorLog(Exception exception)
        {
            ExceptionLogModel exceptionLog = new ExceptionLogModel
            {
                ApplicationName = Assembly.GetExecutingAssembly().FullName.Split(',')[0],
                ExceptionType = typeof(Exception).ToString(),
                Message = exception.Message,
                ExceptionDetails = exception.StackTrace
            };
            //exceptionLog.RequestUrl = HttpContext.Request.Url.ToString();\
            ExceptionLogs exceptionLogs = new ExceptionLogs();
            exceptionLogs.ApplicationName = exceptionLog.ApplicationName;
            exceptionLogs.ExceptionType= exceptionLog.ExceptionType;
            exceptionLogs.Message = exceptionLog.Message;
            exceptionLogs.ExceptionDetails = exceptionLog.ExceptionDetails;
            exceptionLogs.CreatedDateTime = DateTime.Now;

            await _contextDb.ExceptionLogs.AddAsync(exceptionLogs);
            return await _contextDb.SaveChangesAsync()>0;
        }
    }
}
