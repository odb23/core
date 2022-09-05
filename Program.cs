using Core.Services;
using System.Runtime.Serialization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IResponseFormatter, HtmlResponseFormatter>();
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

app.MapGet("/", () => "Hello World!");

app.Run();
