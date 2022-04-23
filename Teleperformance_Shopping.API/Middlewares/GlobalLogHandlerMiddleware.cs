using System.Diagnostics;

namespace Teleperformance_Shopping.API.Middlewares
{
    public class GlobalLogHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public GlobalLogHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            Stopwatch sw = Stopwatch.StartNew();
            Console.WriteLine($"[Request]  HTTP {context.Request.Method} - {context.Request.Path}");
            await _next(context);
            sw.Stop();
            Console.WriteLine($"[Response] HTTP {context.Request.Method} - " +
                $"{context.Request.Path} responded {context.Response.StatusCode} in {sw.ElapsedMilliseconds} ms");
        }
    }

    public static class GlobalLogHandlerMiddlewareExtension
    {
        public static IApplicationBuilder UseCustomLoggingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<GlobalLogHandlerMiddleware>();
        }
    }
}
