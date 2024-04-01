using MiddlewareExample.CustomMiddleware;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<CustomMiddleware>();
var app = builder.Build();

//middleware 1
app.Use(async (HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("Middleware 1");
    await next(context);
});

//middleware 2
app.UseMiddleware<CustomMiddleware>();

//middleware 3
app.Run(async (HttpContext context) =>
{
    await context.Response.WriteAsync("Middleware 3");
});

app.Run();
