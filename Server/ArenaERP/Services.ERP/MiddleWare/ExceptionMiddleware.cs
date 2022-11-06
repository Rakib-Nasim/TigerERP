using ModelClass.ERP.ViewModel;
using SecurityBLLManager.ERP.LoggerBLLManager;
using System.Net;
using System.Text.Json;

namespace Services.ERP.MiddleWare
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IHostEnvironment _env;
        private readonly ILoggerBLLManager _loggerBLLManager;
        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger,
            ILoggerBLLManager loggerBLLManager,
            IHostEnvironment env)
        {
            _env = env;
            _logger = logger;
            _next = next;
            _loggerBLLManager=loggerBLLManager;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var response = _env.IsDevelopment()
                    ? new ApiException(context.Response.StatusCode, ex.Message, ex.StackTrace?.ToString())
                    : new ApiException(context.Response.StatusCode, "Internal Server Error");

                var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

                var json = JsonSerializer.Serialize(response, options);

                await context.Response.WriteAsync(json);
                await _loggerBLLManager.SaveErrorLog(ex);

            }
        }
    }
}
