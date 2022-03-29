using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace ClientPart.Middlewares
{
    //public class GlobalExceptionHandlerMiddleware
    //{
    //    private readonly RequestDelegate _next;
    //    public GlobalExceptionHandlerMiddleware(RequestDelegate next)
    //    {
    //        _next = next;
    //    }
    //    public async Task InvokeAsync(HttpContext httpContext)
    //    {
    //        var statusCode = httpContext.Response.StatusCode;

    //        switch (statusCode)
    //        {
    //            case 401:
    //            case 403:
    //            {
    //                httpContext.Response.Redirect("/Home/Error");
    //                break;
    //            }
    //        }      

    //        await _next(httpContext);
    //    }
    //}
}
