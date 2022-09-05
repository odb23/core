namespace Core.Services
{
    public class HtmlResponseFormatter : IResponseFormatter
    {
        private int _responseCounter = 0;

        public async Task Format(HttpContext context, string content)
        {
            context.Response.ContentType = "text/html";
            await context.Response.WriteAsync($"<h2>Response {++this._responseCounter}</h2> <p>\n{content}</p>");
        }
    }
}
