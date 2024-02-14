using System.Net;
using System.Net.Mime;
using System.Text.Json;
using API.Errors;

namespace API.Middleware
{
    public class ExceptionMiddleware
    {
        private RequestDelegate _next;
        private ILogger<ExceptionMiddleware> _logger;
        private IHostEnvironment _env;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _env = env;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch(Exception exception) 
            {
                _logger.LogError(exception, exception.Message); 
                httpContext.Response.ContentType = "application/json";
                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                // set response and options
                var response = _env.IsDevelopment()?
                new ApiException(httpContext.Response.StatusCode, exception.Message, exception.StackTrace?.ToString())
                : new  ApiException(httpContext.Response.StatusCode, "Internal Server Error");

                var options = new JsonSerializerOptions{ PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

                // writes response and options into a stream and 
                //assigns it to the json
                var json = JsonSerializer.Serialize(response, options);

                // Writes json asynchronously to the response body
                await httpContext.Response.WriteAsync(json);
            }
        }
    }
}