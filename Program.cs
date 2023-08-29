using DurableIsolated;
using Microsoft.DurableTask.Client;
using Microsoft.DurableTask.Worker;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.ApplicationInsights;

var builder = new HostBuilder();
/// The following defaults are configured:
/// <list type="bullet">
///     <item><description>A default set of converters.</description></item>
///     <item><description>Configures the default <see cref="JsonSerializerOptions"/> to ignore casing on property names.</description></item>
///     <item><description>Integration with Azure Functions logging.</description></item>
///     <item><description>Adds environment variables as a configuration source.</description></item>
///     <item><description>Adds command line arguments as a configuration source.</description></item>
///     <item><description>Output binding middleware and features.</description></item>
///     <item><description>Function execution middleware.</description></item>
///     <item><description>Default gRPC support.</description></item>
/// </list>
builder.ConfigureFunctionsWorkerDefaults(worker => {
        worker.UseMiddleware<CustomDurableMiddleware>();
    });
builder.ConfigureLogging(logging => {
    logging.AddApplicationInsights();
    logging.AddFilter<ApplicationInsightsLoggerProvider>("", LogLevel.Information);
});
var host = builder.Build();

await host.RunAsync();
