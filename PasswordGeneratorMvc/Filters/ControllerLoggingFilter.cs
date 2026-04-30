using Microsoft.AspNetCore.Mvc.Filters;
namespace PasswordGeneratorMvc.Filters
{
    public class ControllerLoggingFilter : IActionFilter
    {
        private readonly ILogger<ControllerLoggingFilter> _logger;

        public ControllerLoggingFilter(ILogger<ControllerLoggingFilter> logger)
        {
            _logger = logger;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.LogInformation(
                "[CONTROLLER FILTER] OnActionExecuting -> {Action}",
                context.RouteData.Values["action"]);
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            _logger.LogInformation(
                "[CONTROLLER FILTER] OnActionExecuted -> {Action}",
                context.RouteData.Values["action"]);
        }
    }
}
