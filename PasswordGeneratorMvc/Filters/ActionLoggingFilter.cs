using Microsoft.AspNetCore.Mvc.Filters;
namespace PasswordGeneratorMvc.Filters
{
    public class ActionLoggingFilter : IActionFilter
    {
        private readonly ILogger<ActionLoggingFilter> _logger;
        private readonly string _actionLabel;

        public ActionLoggingFilter(ILogger<ActionLoggingFilter> logger, string actionLabel)
        {
            _logger = logger;
            _actionLabel = actionLabel;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.LogInformation(
                "[ACTION FILTER] OnActionExecuting -> Label='{Label}', Action={Action}",
                _actionLabel,
                context.RouteData.Values["action"]);
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            _logger.LogInformation(
                "[ACTION FILTER] OnActionExecuted -> Label='{Label}'",
                _actionLabel);
        }
    }
}
