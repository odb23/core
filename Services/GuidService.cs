namespace Core.Services
{
    public class GuidService : IResponseFormatter
    {
        private readonly Guid _guid = Guid.NewGuid(); 

        public async Task Format(HttpContext context, string content)
        {
            await context.Response.WriteAsync($"<h2>Guid: {this._guid}</h2> <p>\n{content}</p>");
        }
    }
}
