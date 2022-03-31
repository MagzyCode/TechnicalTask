using ClientPart.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace ClientPart.Extensions
{
    public static class GlobalExceptionHandlerExtension
    {
        public static void UseGlobalExceptionHandler(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<GlobalExceptionHandlerMiddleware>();
        }
    }
}
