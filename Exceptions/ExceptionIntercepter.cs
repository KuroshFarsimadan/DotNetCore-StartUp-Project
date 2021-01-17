using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace Project_Skeleton.Exceptions
{
    public class ExceptionsIntercepter
    {
        readonly IHostEnvironment environment;
        readonly RequestDelegate next;
        readonly ILogger<ExceptionsIntercepter> logging;

        public ExceptionsIntercepter(IHostEnvironment environment, RequestDelegate next,
            ILogger<ExceptionsIntercepter> logging)
        {
            this.environment = environment;
            this.next = next;
            this.logging = logging;
        }


        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception exception)
            {
                logging.LogError(exception, exception.Message);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                var response = environment.IsDevelopment() ?
                    new GlobalException(context.Response.StatusCode, exception.Message, exception.StackTrace?.ToString()) :
                    new GlobalException(context.Response.StatusCode, "An error occurred! Please contact our support at 891-156-5454", "");
                var jsonOptions = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
                var jsonResponse = JsonSerializer.Serialize(response, jsonOptions);
                await context.Response.WriteAsync(jsonResponse);
            }
        }
    }
}
