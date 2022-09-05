using Microsoft.Extensions.Options;
using Core.Services;
using System.Runtime.Serialization;

namespace Core
{
    public class CustomMiddleware
    {
        private RequestDelegate _next;
        private IResponseFormatter _formatter;


        public CustomMiddleware(RequestDelegate next, IResponseFormatter formatter)
        {
            this._next = next;
            this._formatter = formatter;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path == "/middleware")
            {
                await this._formatter.Format(context, "Custom middleware");
            }
            await this._next(context);
        }

    }


}
