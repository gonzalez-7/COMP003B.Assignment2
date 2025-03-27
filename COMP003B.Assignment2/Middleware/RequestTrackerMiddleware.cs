namespace COMP003B.Assignment2.Middleware
{
    public class RequestTrackerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestTrackerMiddleware> _logger;

        public RequestTrackerMiddleware(RequestDelegate next, ILogger<RequestTrackerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            _logger.LogInformation($"Request: {context.Request.Method} {context.Request.Path}");
            await _next(context);
            _logger.LogInformation($"Response Status: {context.Response.StatusCode}");
        }
    }
}
