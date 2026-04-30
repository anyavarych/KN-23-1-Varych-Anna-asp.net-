using Microsoft.AspNetCore.Mvc.Filters;
namespace PasswordGeneratorMvc.Filters
{
    public class GlobalLoggingFilter : IActionFilter
    {
        private readonly ILogger<GlobalLoggingFilter> _logger;

        public GlobalLoggingFilter(ILogger<GlobalLoggingFilter> logger)
        {
            _logger = logger;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.LogInformation(
                "[GLOBAL FILTER] OnActionExecuting -> {Controller}::{Action}",
                context.RouteData.Values["controller"],
                context.RouteData.Values["action"]);
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            _logger.LogInformation(
                "[GLOBAL FILTER] OnActionExecuted -> {Controller}::{Action}",
                context.RouteData.Values["controller"],
                context.RouteData.Values["action"]);
        }
    }
}
