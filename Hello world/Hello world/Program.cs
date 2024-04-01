var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async (HttpContext context) =>
{
    context.Response.Headers["MyKey"] = "MyValue";
    context.Response.Headers["Server"] = "MyServer";
    context.Response.ContentType = "text/html";
    await context.Response.WriteAsync("<h1>Hello</h1>");
    await context.Response.WriteAsync("<h2>World</h2>");
}
);

app.Run();
