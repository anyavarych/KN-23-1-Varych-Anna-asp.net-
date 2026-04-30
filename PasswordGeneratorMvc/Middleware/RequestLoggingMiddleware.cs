namespace PasswordGeneratorMvc.Middleware
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLoggingMiddleware> _logger;

        public RequestLoggingMiddleware(RequestDelegate next,
            ILogger<RequestLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            _logger.LogInformation(
                "[MIDDLEWARE] ▶ Request: {Method} {Path}",
                context.Request.Method,
                context.Request.Path);

            await _next(context);

            _logger.LogInformation(
                "[MIDDLEWARE] ◀ Response: {StatusCode} for {Path}",
                context.Response.StatusCode,
                context.Request.Path);
        }
    }

    public static class RequestLoggingMiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestLogging(
            this IApplicationBuilder app)
            => app.UseMiddleware<RequestLoggingMiddleware>();
    }
}

