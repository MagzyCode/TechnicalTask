using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using ServerPart.Models.ErrorModel;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace ServerPart.Middleware.Errors
{
    public class ApiErrorHandlerMiddlaware
    {
        private readonly RequestDelegate _next;

        public ApiErrorHandlerMiddlaware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch
            {
                context.Response.ContentType = "application/json";

                await context.Response.WriteAsync(new ErrorDetails()
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = "Internal Server Error."
                }.ToString());
            }

        }

    }
}
