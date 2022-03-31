using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Threading.Tasks;

namespace ClientPart.Middlewares
{
    public class GlobalExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        public GlobalExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception exception)
            {
                var (errorMessage, statusCode, method, request) = ("", "", "", "");
                var url = "";
                switch (exception)
                {
                    case Refit.ValidationApiException:
                    case Refit.ApiException:
                        var currentApiException = exception as Refit.ApiException;
                        statusCode = currentApiException.StatusCode.ToString();
                        errorMessage = currentApiException.Message;
                        method = currentApiException.HttpMethod.Method;
                        url = $"/Home/Error?message={errorMessage}&statusCode={statusCode}&method={method}";
                        break;
                    default:
                        statusCode = ((HttpStatusCode)exception.HResult).ToString();
                        errorMessage = exception.Message;
                        url = $"/Home/Error?message={errorMessage}&statusCode={statusCode}";
                        break;
                }

                httpContext.Response.Redirect(url);
            }
        }
    }
}
