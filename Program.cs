using Core;
using Core.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<IResponseFormatter, GuidService>();
var app = builder.Build();

// IResponseFormatter formatter = new TextResponseFormatter();
// IResponseFormatter formatter2 = new HtmlResponseFormatter();

app.MapGet("/formatter1", async (HttpContext context, IResponseFormatter formatter) =>
{
    await formatter.Format(context, "Formater 1");
});

app.MapGet("/formatter2", async (HttpContext context, IResponseFormatter formatter)=>
{
    await formatter.Format(context, "Formatter 2");
});

app.UseMiddleware<CustomMiddleware>();
app.UseMiddleware<CustomMiddleware2>();

app.MapGet("/endpoint", CustomEndpoint.EndPoint);
app.MapGet("/", () => "Hello World!");

app.Run();