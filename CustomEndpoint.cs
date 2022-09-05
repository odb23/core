﻿using Core.Services;

namespace Core
{
    public class CustomEndpoint
    {
        public static async Task EndPoint(HttpContext context)
        {
            IResponseFormatter formatter = context.RequestServices.GetRequiredService<IResponseFormatter>();
            await formatter.Format(context, "Custom Endpoint");
        }
    }
}
