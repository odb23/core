namespace Core
{
    public class MiddleWare
    {
        private RequestDelegate _next;

        public MiddleWare (RequestDelegate next)
        {
            this._next = next;
        }

        public async Task Invoke (HttpContext context)
        {
            if (context.Request.Method == HttpMethods.Get && context.Request.Query["custom"] == "true")
            {
                if (!context.Response.HasStarted)
                {
                    context.Response.ContentType = "text/plain";
                }
                await context.Response.WriteAsync(" Class based Custom MiddleWare \n");
            }

            await this._next(context);
        }
    }
}
