using Microsoft.Azure.Functions.Worker.Middleware;
using Microsoft.Azure.Functions.Worker;
using System.Diagnostics;
using Microsoft.Extensions.Logging;
using Microsoft.DurableTask;

namespace DurableIsolated {
    public class CustomDurableMiddleware: IFunctionsWorkerMiddleware {
        public async Task Invoke(FunctionContext context, FunctionExecutionDelegate next) {

            ILogger logger = context.GetLogger<CustomDurableMiddleware>();
            logger.LogInformation("Middleware: {invocationid}", context.InvocationId);

            await next(context);
        }
    }
}