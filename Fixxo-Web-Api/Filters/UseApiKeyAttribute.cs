using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Fixxo_Web_Api.Filters;

public class UseApiKeyAttribute : Attribute, IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var config = context.HttpContext.RequestServices.GetService<IConfiguration>();
        var apiKey = config?.GetValue<string>("ApiKey");

        if (!context.HttpContext.Request.Headers.TryGetValue("x-api-key", out var key))
        {
            context.Result = new UnauthorizedResult();
            return;
        }

        if (!apiKey!.Equals(key))
        {
            context.Result = new UnauthorizedResult();
            return;
        }
        
        await next();
    }
}