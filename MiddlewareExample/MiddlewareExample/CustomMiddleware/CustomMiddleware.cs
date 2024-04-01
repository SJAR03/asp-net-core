
namespace MiddlewareExample.CustomMiddleware
{
    public class CustomMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("My custom middleware - starts");
            await next(context);
            await context.Response.WriteAsync("My custom middleware - ends");
        }
    }
}
