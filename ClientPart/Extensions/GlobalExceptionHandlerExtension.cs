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

        //public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        //{
        //    app.UseExceptionHandler(appError =>
        //    {
        //        appError.Run(async context =>
        //        {
        //            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        //            var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

        //            if (contextFeature != null && context.Response.StatusCode >= 400 && context.Response.StatusCode != 500)
        //            {
        //                context.Response.Redirect($"/Home/Error");
        //            }
        //        });
        //    });
        //}
    }
}
