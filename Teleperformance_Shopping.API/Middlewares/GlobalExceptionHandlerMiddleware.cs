using Microsoft.AspNetCore.Diagnostics;
using Teleperformance_Shopping.API.DTOs;

namespace Teleperformance_Shopping.API.Middlewares
{
    public static class GlobalExceptionHandlerMiddleware
    {
        public static void UseGlobalExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(options =>
            {
                options.Run(async context =>
                {
                    context.Response.ContentType = "application/json";
                    var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();

                    var exception = exceptionFeature.Error;

                    context.Response.StatusCode = 500;

                    await context.Response.WriteAsJsonAsync(ResponseDto<NoContent>.Fail(exception.Message));
                });
            });
        }
    }
}