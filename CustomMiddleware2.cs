using Core.Services;

namespace Core
{
    public class CustomMiddleware2
    {
        private RequestDelegate _next;
        private IResponseFormatter _formatter;


        public CustomMiddleware2(RequestDelegate next, IResponseFormatter formatter)
        {
            this._next = next;
            this._formatter = formatter;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path == "/middleware2")
            {
                Console.WriteLine("Got here");
                await this._formatter.Format(context, "Custom middleware");
            } else
            {
                await this._next(context);
            }

        }

    }
}
