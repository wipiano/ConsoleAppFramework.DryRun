using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace ConsoleAppFramework
{
    /// <summary>
    /// A filter for console applications that logs a message when dry run mode is enabled.
    /// Dry run mode is considered enabled if the <see cref="IDryRunFlag"/> provided by the service provider is true.
    /// </summary>
    public class DryRunFlagFilter : ConsoleAppFilter
    {
        /// <summary>
        /// Invokes the filter. If dry run mode is enabled, logs an informational message.
        /// </summary>
        /// <param name="context">The console application context.</param>
        /// <param name="next">The next filter in the pipeline.</param>
        /// <returns>A <see cref="ValueTask"/> representing the asynchronous operation.</returns>
        public override ValueTask Invoke(ConsoleAppContext context, Func<ConsoleAppContext, ValueTask> next)
        {
            if (context.ServiceProvider.GetService<IDryRunFlag>() is { Value: true })
            {
                context.Logger.LogInformation("dry run mode enabled.");
            }

            return next(context);
        }
    }
}
