namespace api.Middlewares
{
    public class CustomAuthorizationMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomAuthorizationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await _next(context);

            if(context.Response.StatusCode == StatusCodes.Status403Forbidden)
            {
                context.Response.ContentType = "application/json";
                var response = new { Message = "User Unauthorized" };
                await context.Response.WriteAsJsonAsync(response);
            }
        }
    }
}
