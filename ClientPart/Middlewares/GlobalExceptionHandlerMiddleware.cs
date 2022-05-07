using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Text;
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
                var url = new StringBuilder();
                url.Append($"/Home/Error?message={exception.Message}&");

                switch (exception)
                {
                    case Refit.ValidationApiException:
                    case Refit.ApiException:
                        var currentApiException = exception as Refit.ApiException;
                        url.Append($"statusCode={currentApiException.StatusCode}&");
                        url.Append($"method={currentApiException.HttpMethod.Method}");
                        break;
                    default:
                        url.Append($"statusCode={(HttpStatusCode)exception.HResult}");
                        break;
                }

                httpContext.Response.Redirect(url.ToString());
            }
        }
    }
}
