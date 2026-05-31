using Domain.Exceptions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Net;
using System.Text.Json;

namespace Web.MiddleWare
{
    public class MiddleWareExceptionHandler
    {
        private readonly IWebHostEnvironment _env;
        private readonly ILoggerFactory _logger;
        private readonly RequestDelegate _next;
        public MiddleWareExceptionHandler(IWebHostEnvironment env, ILoggerFactory logger, RequestDelegate next)
        {
            _env=env;
            _logger=logger;
            _next=next;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                var result=JsonSerializer.Serialize(new ApiToReturn(500,ex.Message),options);
                result = HandleRequestResult(context,ex, result, options);
                await context.Response.WriteAsync(result);

            }
        }

        private string HandleRequestResult(HttpContext context, Exception ex, string result, JsonSerializerOptions options)
        {
            switch (ex)
            {
                case NotFoundException notFoundException:
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    result = JsonSerializer.Serialize(new ApiToReturn(404, notFoundException.Message, notFoundException.Messages, ex.Message)
                        , options);
                    break;
                case BadRequestEntityException badRequestEntity:
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    result = JsonSerializer.Serialize(new ApiToReturn(404, badRequestEntity.Message, badRequestEntity.Messages, ex.Message)
                        , options);
                    break;
                case ValidationEntityException validationEntity:
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    result = JsonSerializer.Serialize(new ApiToReturn(404, validationEntity.Message,validationEntity.Messages, ex.Message)
                        , options);
                    break;
            }
            return result;
        }
    }
}
