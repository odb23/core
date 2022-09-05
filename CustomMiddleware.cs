using Microsoft.Extensions.Options;
using Core.Services;
using System.Runtime.Serialization;

namespace Core
{
    public class CustomMiddleware
    {
        private RequestDelegate _next;


        public CustomMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task Invoke(HttpContext context, IResponseFormatter formatter, IResponseFormatter formatter2, IResponseFormatter formatter3)
        {
            if (context.Request.Path == "/middleware")
            {
                await formatter.Format(context, String.Empty);
                await formatter2.Format(context, String.Empty);
                await formatter3.Format(context, String.Empty);
            } else
            {
                await this._next(context);
            }
     
        }

    }


}
