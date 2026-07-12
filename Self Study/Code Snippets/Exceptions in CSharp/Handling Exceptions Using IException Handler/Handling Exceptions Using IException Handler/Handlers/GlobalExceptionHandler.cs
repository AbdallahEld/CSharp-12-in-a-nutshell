using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Handling_Exceptions_Using_IException_Handler.Handlers
{
    public class GlobalExceptionHandler (ILogger<GlobalExceptionHandler> logger) : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            logger.LogError(exception, "An unexpected error occurred.");

            var problemDetails = new ProblemDetails
            {
                Title = "An unexpected error occurred on the server.",
                Status = StatusCodes.Status500InternalServerError, 
                Detail = "A technical error has occurred. Please contact support if the issue persists."
            };

            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

            await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

            return true;
        }
    }
}
