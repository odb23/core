using Core;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<FruitOptions>(options =>
{
    options.Name = "Watermelon";
});

var app = builder.Build();

app.UseMiddleware<FruitsMiddleware>();
app.UseMiddleware<MiddleWare>();

app.MapGet("/", () => "Hello World!");

app.Run();
