using Microsoft.Extensions.Options;

namespace Core
{
    public class FruitsMiddleware
    {
        private RequestDelegate _next;
        private FruitOptions _options;

        public FruitsMiddleware() { }

        public FruitsMiddleware(RequestDelegate next, IOptions<FruitOptions> options)
        {
            this._next = next;
            this._options = options.Value;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path == "/fruit")
            {
                await context.Response.WriteAsync($"{this._options.Name}, {this._options.Color}");
            }

            await this._next(context);
        }
    }
}
