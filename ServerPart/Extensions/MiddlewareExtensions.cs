using Microsoft.AspNetCore.Builder;
using ServerPart.Middleware.Authorization;
using ServerPart.Middleware.Errors;

namespace ServerPart.Extensions
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseApiGlobalExceptionHandler(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ApiErrorHandlerMiddlaware>();
        }

        public static IApplicationBuilder UseAuthorizationResponseHelper(this IApplicationBuilder app)
        {
            return app.UseMiddleware<AuthorizationResponceMiddleware>();
        }
    }
}
