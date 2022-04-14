using Microsoft.AspNetCore.Http;
using ServerPart.Models.ErrorModel;
using System.Threading.Tasks;

namespace ServerPart.Middleware.Authorization
{
    public class AuthorizationResponceMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthorizationResponceMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await _next(context);

            if (context.Response.StatusCode == 401)
            {
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(new ErrorDetails()
                {
                    StatusCode = 401,
                    Message = "Unauthorize invoke of action method."
                }.ToString());
            }
        }
    }
}
